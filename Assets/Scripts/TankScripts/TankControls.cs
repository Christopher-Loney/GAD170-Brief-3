using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This class is just hold the data for our player controls.
/// </summary>
[System.Serializable]
public class TankControls
{
    public enum KeyType { Movement, Rotation, Fire }
    public int playerNum = 1;
    public KeyCode forward = KeyCode.W; // the forward button to use
    public KeyCode backwards = KeyCode.S; // the backwards button
    public KeyCode left = KeyCode.A; // the left button
    public KeyCode right = KeyCode.D; // the right button
    public KeyCode fireButton = KeyCode.Space; // the button to fire
    private string joyForward = null;
    private string joyBackward;
    private string joyLeft;
    private string joyRight;
    private string joyShoot;
    private bool fireButtonWasPressed = false; // has the fire button been pressed?

    /// <summary>
    /// If the value returned is postive then the postive axis has been pressed for that key.
    /// if the value returned is negative then the negative axis as been pressed
    /// if the value is 0 then no button has been pressed
    /// </summary>
    /// <param name="codeToCheck"></param>
    /// <returns></returns>
    /// 
    public float ReturnKeyValue(KeyType codeToCheck)
    {
        float currentValue = 0; // the current input value of the code to check
        if (joyForward == null)
        {
            if (playerNum == 1)//player one
            {
                joyForward = "P1 Forward";
                joyBackward = "P1 Backward";
                joyLeft = "P1 Left";
                joyRight = "P1 Right";
                joyShoot = "P1 Shoot";
            }
            else if (playerNum == 2)//player two
            {
                joyForward = "P2 Forward";
                joyBackward = "P2 Backward";
                joyLeft = "P2 Left";
                joyRight = "P2 Right";
                joyShoot = "P2 Shoot";
            }
            else // player 3
            {
                joyForward = "P3 Forward";
                joyBackward = "P3 Backward";
                joyLeft = "P3 Left";
                joyRight = "P3 Right";
                joyShoot = "P3 Shoot";
            }
        }
        switch (codeToCheck)
        {
            case KeyType.Movement:
                {
                    if (Input.GetAxis(joyForward) > 0f || Input.GetKey(forward)) // if we are pressing the forward button
                    {
                        currentValue = 1; // we moving positively.
                    }
                    else if (Input.GetAxis(joyBackward) > 0f || Input.GetKey(backwards)) // if pressing backwards button
                    {
                        currentValue = -1; // we are moving negatively
                    }
                    break;
                }
            case KeyType.Rotation:
                {
                    if (Input.GetAxis(joyRight) > 0.5f || Input.GetKey(right)) // if we are pressing the right button
                    {
                        currentValue = 1; // we are rotating positively.
                    }
                    else if (Input.GetAxis(joyLeft) > 0.5f || Input.GetKey(left))// if we are pressing the left button
                    {
                        currentValue = -1; // we are rotating negatively
                    }
                    break;
                }
            case KeyType.Fire:
                {
                    if (Input.GetButton(joyShoot) || Input.GetKey(fireButton)) // if we are pressing the fire button
                    {
                        currentValue = 1; // the fire button is pressed
                        fireButtonWasPressed = true;
                        //Debug.Log("Fire Pressed");
                    }
                    else if ((Input.GetButtonUp(joyShoot) || Input.GetKeyUp(fireButton)) && fireButtonWasPressed == true)
                    {
                        fireButtonWasPressed = false;
                        currentValue = -1;
                        Debug.Log("Fire Released");
                    }
                    break;
                }
        }

        return currentValue;
    }
}
  
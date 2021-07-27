using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform camMainPos;
    public Transform camAdsPos;
    public GameObject tank;
    public GameObject rotPoint;
    public string joyAim;
    public bool isAiming;
    private Camera cam;
    private Vector3 velocity = Vector3.zero;
    private float smoothTime = 0.3f;
    private Quaternion cameraTargetRot;
    // Start is called before the first frame update
    void Start()
    {
        cam = this.gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetButtonDown(joyAim))
        {
            isAiming = !isAiming;
        }
        if (isAiming)
        {
            cam.transform.position = camAdsPos.position;
            cam.transform.rotation = camAdsPos.rotation;
        }
        else
        {
            Vector3 targetPos = camMainPos.position;

            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
            cam.transform.LookAt(tank.transform);
        }
            
    }
 
}

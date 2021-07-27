using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderGradient : MonoBehaviour
{
    public Gradient gradient = null;
    public Slider slider;
    private Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        image.color = gradient.Evaluate(slider.value/(slider.minValue + slider.maxValue));
    }
}

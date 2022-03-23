using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpBar : MonoBehaviour
{
    Slider slider;
    public bool jumpBarIsFilled;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = 3;
        slider.value = slider.maxValue;
        jumpBarIsFilled = true;
    }

    public void IncreaseEnergy()
    {
        slider.value = slider.value + 1;
        jumpBarIsFilled = true;
    }

    public void DecreaseEnergy()
    {
        slider.value = slider.value - 1;
        if (slider.value == 0)
        {
            jumpBarIsFilled = false;
        }
    }
}

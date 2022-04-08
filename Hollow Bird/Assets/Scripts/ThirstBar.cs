using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirstBar : MonoBehaviour
{

    public Slider slider2;

    public void SetMaxThirst(float thirst)
    {
        slider2.maxValue = thirst;
        slider2.value = thirst;
    }

    public void SetThirst(float thirst)
    {
        slider2.value = thirst;
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // for slider

public class HealthBar : MonoBehaviour
{

    public Slider slider;

    // set max health
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // this simply adjusts slider to match player health
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}

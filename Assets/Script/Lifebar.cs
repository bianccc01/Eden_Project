using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lifebar : MonoBehaviour
{
    public Slider sliderMaxHealth;

    public Slider sliderHealth;

    public void SetMaxHealth(float health)
    {
        sliderMaxHealth.value = health;
    }

    public void SetCurrentHealth(float health)
    {
        sliderHealth.value = health;
    }

    private void FixedUpdate() {
        sliderHealth.maxValue = sliderMaxHealth.value;
    }

    public float getMaxValue()
    {
        return sliderMaxHealth.value;
    }
}

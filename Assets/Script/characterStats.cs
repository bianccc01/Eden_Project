using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class characterStats : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public TMP_Text maxHealthText;
    public TMP_Text currentHealthText;
    public float maxOx = 100f;
    public float currentOx;
    public TMP_Text maxOxText;
    public TMP_Text currentOxText;



    void Start()
    {
        currentHealth = PlayerPrefs.GetFloat("CurrentHealth");
        currentOx = (int)PlayerPrefs.GetFloat("Ossigeno");
        maxHealth = PlayerPrefs.GetFloat("MaxHealth");
        UpdateStats();
    }

    public void setMaxHealth(float max)
    {
        this.maxHealth = max;
        
        UpdateStats();

    }

    public void setCurrentHealth(float current)
    {
        this.currentHealth = current;
        UpdateStats();
    }


    public void setMaxOx(float max)
    {
        this.maxOx = max;

        UpdateStats();

    }

    public void setCurrentOx(float current)
    {
        this.currentOx = current;
        UpdateStats();
    }



    public void UpdateStats()
    {


        maxHealthText.text = maxHealth.ToString();
       
        currentHealthText.text = currentHealth.ToString();

        maxOxText.text = maxOx.ToString();

        currentOxText.text = currentOx.ToString();
    }
}

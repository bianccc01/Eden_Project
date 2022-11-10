using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class PlayerHealth : MonoBehaviour
{

    public Lifebar lifebar;
    static float maxHealth = 250f; 
    static float currentHealth = 200;

    public float MaxOx = 100;

    static float CurrentOx;

    public HealthBar OxBar;

    private characterStats cs;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        lifebar.SetMaxHealth(maxHealth);
        lifebar.SetCurrentHealth(currentHealth);
        CurrentOx = MaxOx;
        OxBar.SetMaxHealth(MaxOx);

        cs = new characterStats();
        cs.setCurrentHealth(currentHealth);
        cs.setMaxHealth(maxHealth);
        cs.setCurrentOx(CurrentOx);
        cs.setMaxOx(MaxOx);

    }

    // Update is called once per frame
    void Update()
    {
        lifebar.SetCurrentHealth(currentHealth);
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        LessOx();
        RefreshMaxHealth();

        cs.setCurrentHealth(currentHealth);
        cs.setMaxHealth(maxHealth);
       
    }


    void RefreshMaxHealth()
    {
        if (CurrentOx <= 0f )
        {
            if (maxHealth > 0)
            {
                maxHealth -= 0.01f;
            }
            
            lifebar.SetMaxHealth(maxHealth);
        }
        
    }

    void LessOx()
    {
        if(CurrentOx <= 0)
        {
            OxBar.SetHealth(0);
        }
        else 
        {
            CurrentOx -= 0.01f;
            OxBar.SetHealth(CurrentOx);
        }
    }


    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        lifebar.SetCurrentHealth(currentHealth);
    }


    void OnRegenerate()
    {
        lifebar.SetCurrentHealth(maxHealth);
        
    }

    private void OnCollisionExit2D(Collision2D theCollision)
    {
        if (theCollision.gameObject.tag == "Enemy")
        {
            TakeDamage(5);
        }
    }
}

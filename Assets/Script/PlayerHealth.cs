using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public Lifebar lifebar;
    public float maxHealth = 250f; 
    public float currentHealth;

     public float MaxOx = 100;

    public float CurrentOx;

    public HealthBar OxBar;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        lifebar.SetMaxHealth(maxHealth);
        lifebar.SetCurrentHealth(maxHealth);
        CurrentOx = MaxOx;
        OxBar.SetMaxHealth(MaxOx);
    }

    // Update is called once per frame
    void Update()
    {
        LessOx();
        RefreshMaxHealth();
    }


    void RefreshMaxHealth()
    {
        if (CurrentOx <= 0f )
        {
            if(currentHealth > 0)
            {
                currentHealth-=0.05f;
            }
            lifebar.SetCurrentHealth(currentHealth);
            
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
            CurrentOx -= 0.05f;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{

    public Lifebar lifebar;
    public float maxHealth = 250f; 
    public float currentHealth = 200;

    public float MaxOx = 100;

    public float CurrentOx = 100f;

    public HealthBar OxBar;

   


    void OnEnable() 
    { 
        CurrentOx = PlayerPrefs.GetFloat("Ossigeno");
        maxHealth = PlayerPrefs.GetFloat("MaxHealth");
        currentHealth = PlayerPrefs.GetFloat("CurrentHealth"); 
    } 


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        lifebar.SetMaxHealth(maxHealth);
        lifebar.SetCurrentHealth(currentHealth);
        OxBar.SetMaxHealth(MaxOx);

      

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

       
    }


    void RefreshMaxHealth()
    {
        if (CurrentOx <= 0f )
        {
            if (maxHealth > 0)
            {
                maxHealth -= 1f;
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
            CurrentOx -= 0.005f;
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

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public Lifebar lifebar;
    public float maxHealth = 250f; 
    public float currentHealth = 200;

    public float MaxOx = 100f;

    public float CurrentOx = 100f;

    public float RadioAtt = 0f;

    public float RadioMax = 200f;

    public HealthBar OxBar;

    public HealthBar RadioBar;


   


    void OnEnable()
    { 
        RadioAtt = PlayerPrefs.GetFloat("Radioattivita");
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
        RadioBar.SetMaxHealth(RadioMax);
      

    }

    // Update is called once per frame
    void Update()
    {
        RadioBar.SetHealth(RadioAtt);
        lifebar.SetCurrentHealth(currentHealth);

        OxBar.SetHealth(CurrentOx);
        
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if(gameObject.scene.buildIndex != 5){
             LessOx();
        }
       
        RefreshMaxHealth();

       
    }


    private void OnCollisionEnter2D(Collision2D theCollision)
    {
        if (theCollision.gameObject.tag == "Enemy")
        {
            TakeDamage(5f);
        }

        

        if(theCollision.gameObject.tag== "RicaricaOssigeno")
{
        CurrentOx=MaxOx;
}        
    }

    private void OnCollisionStay2D(Collision2D other) {
        
        if (other.gameObject.tag == "Lupo")
        {
            TakeDamage(0.5f);
        }
    }


    void RefreshMaxHealth()
    {
        if (CurrentOx <= 0f )
        {
            if (maxHealth > 0)
            {
                maxHealth -= 0.01f;
                lifebar.SetMaxHealth(maxHealth);
            }
            else
                SceneManager.LoadScene(7);
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
            CurrentOx -= 0.003f;
        }
    }


    void TakeDamage(float damage)
    {
        currentHealth -= damage;
        lifebar.SetCurrentHealth(currentHealth);
    }

    private void OnCollisionExit2D(Collision2D theCollision)
    {
        if (theCollision.gameObject.tag == "Enemy")
        {
            TakeDamage(5);
        }
    }
}

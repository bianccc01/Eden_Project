using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lupo : MonoBehaviour
{
    public Player player2;
    public float moltiplicatoreDifficolta = 1f; //Temporaneo
    public float velocitaNemico;

    public int maxHealth = 200; //Test per un eventuale barra della salute
    public int currentHealth;

    private float time;

    public bool grounded;
    public float jumpamount = 100; //Altezza del salto
    public float gravityScale = 10; //Gravità per il salto verso l'alto
    public float fallingGravityScale = 40; //Gravità per la discesa verso il basso

    public int platform;
    public int platformPlayer;
    public float puntoX;

    public HealthBar healthBar;

    Rigidbody2D rb;

    Vector3 characterScale;
    
    
    // Start is called before the first frame update
    void Start()
    {
       rb=GetComponent<Rigidbody2D>();
       currentHealth = maxHealth;
       healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

        platformPlayer = player2.getPlatform();   

        percorso(platformPlayer);

        

        
      
        
        
        
        if(currentHealth == 0)
        {
            Destroy(gameObject);
            PlayerPrefs.SetInt("StatoNemico",0);
            SceneManager.LoadScene(5);
        }

        updateScale();

        

        transform.localScale = characterScale;
    
    }



    private void updateScale ()
    {
        characterScale = transform.localScale;

        if (rb.velocity.x > 0)
        {
            characterScale.x = -0.9f;
        }

        else if (rb.velocity.x < 0)
        {
            characterScale.x = 0.9f;
        }

        else if (puntoX >= rb.position.x)
        {
            characterScale.x = -0.9f;
        }

        else characterScale.x = 0.9f;
        transform.localScale = characterScale;
    }
    



    private void percorso (int p)
    {
        if (platform != p)
        {
            if(platform == 0)
            {
                puntoX = -3f;
                transform.position = Vector2.MoveTowards(rb.position,new Vector2(puntoX,rb.position.y),
                moltiplicatoreDifficolta * velocitaNemico * Time.fixedDeltaTime);
            if(rb.position == new Vector2(puntoX,rb.position.y)) {
            rb.velocity = new Vector2(10,25);
             RefreshGravity();
            }

            }

            else if (platform == 3)
            {
                puntoX = 1.54f;
                transform.position = Vector2.MoveTowards(rb.position,new Vector2(puntoX,rb.position.y),velocitaNemico * Time.fixedDeltaTime);
            
            if(rb.position == new Vector2(puntoX,rb.position.y))
            rb.velocity = new Vector2(12,23);
             RefreshGravity();
            }

            else if (platform == 2)
            {
                puntoX = 3.60f;
                transform.position = Vector2.MoveTowards(rb.position,new Vector2(puntoX,rb.position.y),velocitaNemico * Time.fixedDeltaTime);
            
            if(rb.position == new Vector2(puntoX,rb.position.y))
            rb.velocity = new Vector2(-20,30);
             RefreshGravity();
            }

            else if (platform == 4)
            {
                puntoX = -18f;
                transform.position = Vector2.MoveTowards(rb.position,new Vector2(-18f,rb.position.y),velocitaNemico * Time.fixedDeltaTime);
                puntoX = -14f;
                transform.position = Vector2.MoveTowards(rb.position,new Vector2(-14f,rb.position.y),velocitaNemico * Time.fixedDeltaTime);
                platform = 0;
            }
                
            else 
            {
                puntoX = -18f;
                transform.position = Vector2.MoveTowards(rb.position,new Vector2(-18f,rb.position.y),velocitaNemico * Time.fixedDeltaTime);
            }
        }

        else 
        {
            puntoX = player2.getPosition().x;
            transform.position = Vector2.MoveTowards(rb.position,player2.getPosition(),velocitaNemico * Time.fixedDeltaTime);
        }
    }


    
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Bullet"){
            TakeDamage(100);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        
        if (other.gameObject.tag == "Wall")
        {
            characterScale.x = characterScale.x * (-1);
        }

        if (other.gameObject.tag == "Floor")
        {
            grounded = true;
        }

        if (other.gameObject.tag == "Piattaforma 1")
        {
            platform = 1;
        }

        if (other.gameObject.tag == "Piattaforma 2")
        {
            platform = 2;
        }

        if (other.gameObject.tag == "Piattaforma 3")
        {
            platform = 3;
        }

        if (other.gameObject.tag == "Piattaforma 4")
        {
           platform = 4;
        }

        if (other.gameObject.tag == "Piattaforma 5")
        {
            platform = 5;
        }
    }

     private void RefreshGravity()
    {

        if (rb.velocity.y >= 0)
        {

            rb.gravityScale = gravityScale;

        }

        else if (rb.velocity.y < 0)
        {

            rb.gravityScale = fallingGravityScale;

        }


    }
}

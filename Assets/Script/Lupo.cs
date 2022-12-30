using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lupo : MonoBehaviour
{
    public Transform player;
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

        
        characterScale = transform.localScale;

        /*if(player.position.y >  rb.position.y + 0.40f)
        {
            if(rb.position.x < -17)
            {
                characterScale.x = characterScale.x * (-1);
                transform.position = Vector2.MoveTowards(rb.position,new Vector2(rb.position.x +3,rb.position.y),
            moltiplicatoreDifficolta * velocitaNemico * Time.fixedDeltaTime);
            }
            
            else if (rb.position.x > 9)
            {
                characterScale.x = characterScale.x * (-1);
                transform.position = Vector2.MoveTowards(rb.position,new Vector2(rb.position.x -3,rb.position.y),
            moltiplicatoreDifficolta * velocitaNemico * Time.fixedDeltaTime);
            }
            
            else if(grounded && rb.velocity.y == 0 && time > 1f)
            {
                rb.AddForce(new Vector2(characterScale.x*(-1),2) * 40,ForceMode2D.Impulse);
                
                time = 0f;
            }
        }

        else 
        {
            transform.position = Vector2.MoveTowards(rb.position,new Vector2(player.transform.position.x,rb.position.y),
            moltiplicatoreDifficolta * velocitaNemico * Time.fixedDeltaTime);

            if(player.transform.position.x < transform.position.x){
            characterScale.x = 0.9f;
        }

            if(player.transform.position.x > transform.position.x){
            characterScale.x = -0.9f;
        }

        
        }

        transform.localScale = characterScale;
*/
        
        
        
       


        if(currentHealth == 0)
        {
            Destroy(gameObject);
            PlayerPrefs.SetInt("StatoNemico",0);
            SceneManager.LoadScene(5);
        
        }
    }



    private void percorso (int p)
    {
        if (platform != p)
        {
            if(platform == 0)
            {
                transform.position = Vector2.MoveTowards(rb.position,new Vector2(-3f,rb.position.y),
                moltiplicatoreDifficolta * velocitaNemico * Time.fixedDeltaTime);
            if(rb.position == new Vector2(-3f,rb.position.y))
            rb.velocity = new Vector2(10,30);
             RefreshGravity();

            }

            else if (platform == 3)
            {
                transform.position = Vector2.MoveTowards(rb.position,new Vector2(1.54f,rb.position.y),velocitaNemico * Time.fixedDeltaTime);
            
            if(rb.position == new Vector2(1.54f,rb.position.y))
            rb.velocity = new Vector2(10,30);
             RefreshGravity();
            }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lupo : MonoBehaviour
{
    public Transform player;
    public float moltiplicatoreDifficolta = 1f; //Temporaneo
    public float velocitaNemico;

    public int maxHealth = 200; //Test per un eventuale barra della salute
    public int currentHealth;

    private float time;

    public bool grounded;
    public float jumpamount = 100; //Altezza del salto
    public float gravityScale = 10; //Gravità per il salto verso l'alto
    public float fallingGravityScale = 40; //Gravità per la discesa verso il basso

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
        time += Time.fixedDeltaTime;
        
        characterScale = transform.localScale;

        if(player.position.y >  rb.position.y + 0.40f)
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
                transform.position = Vector2.MoveTowards(rb.position,new Vector2(rb.position.x -2,rb.position.y),
            moltiplicatoreDifficolta * velocitaNemico * Time.fixedDeltaTime);
            }
            
            else if(grounded && rb.velocity.y == 0 && time > 1f)
            {
                rb.AddForce(new Vector2(characterScale.x*(-1),2) * 40,ForceMode2D.Impulse);
                RefreshGravity();
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

        
        
        
       


        if(currentHealth == 0)
        {
            Destroy(gameObject);
            PlayerPrefs.SetInt("StatoNemico",0);
            SceneManager.LoadScene(5);
        
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

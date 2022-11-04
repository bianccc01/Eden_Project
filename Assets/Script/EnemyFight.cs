using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFight : MonoBehaviour
{
    public Transform player;
    public float moltiplicatoreDifficolta = 1f; //Temporaneo
    public float velocitaNemico;

    public int maxHealth = 200; //Test per un eventuale barra della salute
    public int currentHealth;

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


        characterScale = transform.localScale;

        if(player.position.y >  rb.position.y + 2.40f)
        {
            if(rb.position.x <= -17 || rb.position.x >= 9)
            {
                characterScale.x = characterScale.x * (-1);
            }
            transform.position = Vector2.MoveTowards(rb.position,
            new Vector2(transform.position.x + (characterScale.x * (-4)) ,rb.position.y),
            moltiplicatoreDifficolta* velocitaNemico * Time.fixedDeltaTime);
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
        }
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Bullet"){
            TakeDamage(8);
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
    }
}

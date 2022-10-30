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
        transform.position = Vector2.Lerp(rb.position,new Vector2(player.transform.position.x,(-3.52f)),moltiplicatoreDifficolta* velocitaNemico * Time.fixedDeltaTime);
        
        Vector3 characterScale = transform.localScale;
        
        if(player.transform.position.x < transform.position.x){
            characterScale.x = 1;
        }

        if(player.transform.position.x > transform.position.x){
            characterScale.x = -1;
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
}

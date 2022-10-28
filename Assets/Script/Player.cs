using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    private Rigidbody2D rb;

    /*Componenti per il movimento*/
    public float moveSpeed = 3f; //Velocita di movimento
    private Vector2 moveInput; //Direzione stabilita dall'input dell'utente
    private bool canMove = true; //se colpito dal nemico il personaggio non potrà muoversi fino a che non tocca terra


    public int maxHealth = 200; 
    public int currentHealth;

    public HealthBar healthBar;


    public int MaxOx = 100;

    public int CurrentOx;

    public HealthBar OxBar;

    /*Componenti per il salto*/
    private bool jump = false;
    private bool isGrounded = false;
    public float jumpamount = 100; //Altezza del salto
    public float gravityScale = 10; //Gravità per il salto verso l'alto
    public float fallingGravityScale = 40; //Gravità per la discesa verso il basso



    private void Start()
    {
        currentHealth = maxHealth;
        CurrentOx = MaxOx;
        healthBar.SetMaxHealth(maxHealth);
        OxBar.SetMaxHealth(MaxOx);
        rb = GetComponent<Rigidbody2D>(); //inizializzo le componenti necessarie per rendere il player un corpo rigido
    }

    void FixedUpdate()
    {
        //(EQUIVALENTE)     rb.velocity = new Vector2(moveInput.x * moveSpeed ,rb.velocity.y);
        if (canMove)
        {
            PlayerMove();
        }

            PlayerJump();

            LessOx();



    }

    /*Funzione che viene richiamata appena entra in collisione con un oggetto*/
    private void OnCollisionEnter2D(Collision2D theCollision)
    {
        if (theCollision.gameObject.tag == "Floor")
        {
            isGrounded = true;
            canMove = true;
        }

        if (theCollision.gameObject.tag == "Enemy")
        {
            rb.AddForce(new Vector2(-(transform.localScale.x), 3) * 30, ForceMode2D.Impulse);
            RefreshGravity();
            isGrounded = false;
        }

    }


    /*Funzione che viene richiamata appena esce dalla collisione con un oggetto*/
    private void OnCollisionExit2D(Collision2D theCollision)
    {
        if (theCollision.gameObject.tag == "Floor")
        {
            isGrounded = false;
        }

        if (theCollision.gameObject.tag == "Enemy")
        {
            TakeDamage(5);
            canMove = false;
        }
    }


    /* Tasti (W,D)*/
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
 
    /*Tasto: Spazio*/
    public void OnJump()
    {
        if (isGrounded == true)
        {
            jump = true;
        }
    }

    private void PlayerJump()
    {
        if (jump == true && isGrounded == true)
        {
            rb.AddForce(Vector2.up * jumpamount, ForceMode2D.Impulse);

            RefreshGravity();
            jump = false;
        }
    }

    private void PlayerMove()
    {

        transform.Translate(moveInput * moveSpeed * Time.fixedDeltaTime);

        Vector3 characterScale = transform.localScale;

        if (moveInput.x > 0)
        {
            characterScale.x = 1;
        }

        if (moveInput.x < 0)
        {
            characterScale.x = -1;
        }

        transform.localScale = characterScale;
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

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void LessOx()
    {
        CurrentOx -= 1;
        OxBar.SetHealth(CurrentOx);
    }

}






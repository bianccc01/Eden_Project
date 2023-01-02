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

    /*Componenti per il salto*/
    private bool jump = false;
    private bool isGrounded = false;
    public float jumpamount = 100; //Altezza del salto
    public float gravityScale = 10; //Gravità per il salto verso l'alto
    public float fallingGravityScale = 40; //Gravità per la discesa verso il basso

    public int platform;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();  //inizializzo le componenti necessarie per rendere il player un corpo rigido
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            PlayerMove();
        }
            PlayerJump();
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

            if(rb.position.x - theCollision.gameObject.transform.position.x < 0 )
            {
                rb.AddForce(new Vector2(-1,3) * 30, ForceMode2D.Impulse);
                RefreshGravity();
                isGrounded = false;
            }

            else rb.AddForce (new Vector2(1,3) * 30 ,ForceMode2D.Impulse);
           
            RefreshGravity();
            isGrounded = false;
        }


        if (theCollision.gameObject.tag == "Piattaforma 0")
        {
            platform = 0;
        }

        if (theCollision.gameObject.tag == "Piattaforma 1")
        {
            platform = 1;
        }

        if (theCollision.gameObject.tag == "Piattaforma 2")
        {
            platform = 2;
        }

        if (theCollision.gameObject.tag == "Piattaforma 3")
        {
            platform = 3;
        }

        if (theCollision.gameObject.tag == "Piattaforma 4")
        {
           platform = 4;
        }

        if (theCollision.gameObject.tag == "Piattaforma 5")
        {
            platform = 5;
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
            characterScale.x = 0.9f;
        }

        if (moveInput.x < 0)
        {
            characterScale.x = -0.9f;
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


    public Vector2 getPosition(){
        return rb.position;
    }

    public int getPlatform ()
    {
        return this.platform;
    }

    
    public void down()
    {
        moveInput = new Vector2(0,-1);
    }

    public void left()
    {
        moveInput = new Vector2(-1,0);
    }

    public void right()
    {
        moveInput = new Vector2(1,0);
    }

    public void up()
    {
        moveInput = new Vector2(0,1);
    }

    public void stop()
    {
        moveInput = new Vector2(0,0);
    }

    public void PlayerJumpTouch()
    {
        if (isGrounded == true)
        {
            rb.AddForce(Vector2.up * jumpamount, ForceMode2D.Impulse);

            RefreshGravity();
        }
    }


    

    


    

}






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
        

        public int salute = 5; //Test per un eventuale barra della salute

        /*Componenti per il salto*/
        private bool jump = false;
        private bool isGrounded = false; 
        public float jumpamount = 100; //Altezza del salto
        public float gravityScale = 10; //Gravità per il salto verso l'alto
        public float fallingGravityScale = 40; //Gravità per la discesa verso il basso

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>(); //inizializzo le componenti necessarie per rendere il player un corpo rigido
        }

        void FixedUpdate()
        {
            //(EQUIVALENTE)     rb.velocity = new Vector2(moveInput.x * moveSpeed ,rb.velocity.y);
            if(canMove)
            {
                transform.Translate(moveInput * moveSpeed * Time.fixedDeltaTime);
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

            if(theCollision.gameObject.tag == "Enemy")
            {
                rb.AddForce(new Vector2(-1,2) * 20, ForceMode2D.Impulse);
            }
            
        }


        /*Funzione che viene richiamata appena esce dalla collisione con un oggetto*/
        private void OnCollisionExit2D(Collision2D theCollision)
        {
            if (theCollision.gameObject.tag == "Floor")
            {
                isGrounded = false;
            }

            if(theCollision.gameObject.tag == "Enemy")
            {
                salute--;
                print("ora ti rimangono "+ salute + " vite");
                canMove = false;
            }
        }



        void OnMove(InputValue value)
        {
            moveInput = value.Get<Vector2>();
        }

        void OnFire()
        {
            print("fired ");
        }

        public void OnJump()
        {
            if (isGrounded == true)
            {
                print("Jumping");
                jump = true;
            }
        }

        private void PlayerJump()
        {
            if (jump == true && isGrounded == true)
            {
                rb.AddForce(Vector2.up * jumpamount, ForceMode2D.Impulse);
                
                if (rb.velocity.y >= 0)
                {
                    rb.gravityScale = gravityScale;
                }
                else if (rb.velocity.y < 0)
                {
                    rb.gravityScale = fallingGravityScale;
                }
                jump = false;
            }
        }
    }


    

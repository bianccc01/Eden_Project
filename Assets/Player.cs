    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class Player : MonoBehaviour
    {
        public float moveSpeed = 3f;
        private Vector2 moveInput;

        private bool canMove = true;
        private Rigidbody2D rb;

        public int salute = 5;

        //Componenti per il salto
        private bool jump = false;

        private bool contatto = false;
    
        private bool isGrounded = false;
        public float jumpamount = 100; //altezza del salto
        public float gravityScale = 10; //Gravità per il salto verso l'alto
        public float fallingGravityScale = 40; //Gravità per la discesa verso il basso

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
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
                Debug.Log("Here");
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


    

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class esploratore : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 0.1f;
    private Vector2 moveInput;
    //public DialogueScript Dialogo;
    public Inventario inventario;
    public Animator animator;

    public GameObject box;

    public int canTalk;

    public bool interact;

    
    private void Awake()
    {
        inventario = new Inventario(9);
    }

    
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        canTalk = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(canTalk == 0 || !interact)
        {
            box.SetActive(false);
        }

        else box.SetActive(true);

       transform.Translate(moveInput*moveSpeed*Time.fixedDeltaTime);

        Vector3 characterScale = transform.localScale;

        if (moveInput.x > 0)
        {
            characterScale.x = 0.75f;
        }

        if (moveInput.x < 0)
        {
            characterScale.x = -0.75f;
        }

        transform.localScale = characterScale;

    }
   
    //viene chiamato quando si effettuano collisioni 
    private void OnCollisionEnter2D(Collision2D theCollision)
    {
        if (theCollision.gameObject.tag == "Enemy")
        {
            PlayerPrefs.SetFloat("PosizioneY",rb.position.y);
            PlayerPrefs.SetFloat("PosizioneX",rb.position.x);
            
            if(theCollision.gameObject.ToString() == "Enemy_explorer3 (UnityEngine.GameObject)")
            {
                PlayerPrefs.SetInt("Nemico",3);
                SceneManager.LoadScene(6);
            }

            if(theCollision.gameObject.ToString() == "Enemy_explorer1 (UnityEngine.GameObject)")
            {
                PlayerPrefs.SetInt("Nemico",1);
                SceneManager.LoadScene(6);
            }

            if(theCollision.gameObject.ToString() == "Enemy_explorer2 (UnityEngine.GameObject)")
            {
                PlayerPrefs.SetInt("Nemico",2);
                SceneManager.LoadScene(6);
            }

            if(theCollision.gameObject.ToString() == "Enemy_explorer4 (UnityEngine.GameObject)")
            {
                PlayerPrefs.SetInt("Nemico",4);
                SceneManager.LoadScene(9);
            }
            
            
            
            
        }

        
        
        if (theCollision.gameObject.tag == "Png1")
        {
            canTalk = 1;
        }

        if (theCollision.gameObject.tag == "Png2")
        {
            canTalk = 2;
        }

        if (theCollision.gameObject.tag == "Png3")
        {
            canTalk = 3;
        }
        if (theCollision.gameObject.tag == "Png5")
        {
            canTalk = 5;
        }
       
        if (theCollision.gameObject.tag == "Door")
        {
            SceneManager.LoadScene(8);
        }

        if (theCollision.gameObject.tag == "Door3")
        {
            SceneManager.LoadScene(5);
            PlayerPrefs.SetFloat("PosizioneY",20.45f);
            PlayerPrefs.SetFloat("PosizioneX",-4.55f);
            PlayerPrefs.SetInt("Nemico",0);
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        
        if (other.gameObject.tag == "Png1")
       {
         interact = false;
         canTalk = 0;
       }

        if (other.gameObject.tag == "Png2")
        {
            interact = false;
            canTalk = 0;
        }

        if (other.gameObject.tag == "Png3")
        {
            interact = false;
            canTalk = 0;
        }

        if (other.gameObject.tag == "Png5")
        {
            interact = false;
            canTalk = 0;
        }
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void down()
    {
        moveInput = new Vector2(0,-1);
        animator.SetFloat("SpeedY", -1.5f);
    }

    public void left()
    {
        moveInput = new Vector2(-1,0);
        animator.SetFloat("SpeedX", -1.5f);
    }

    public void right()
    {
        moveInput = new Vector2(1,0);
        animator.SetFloat("SpeedX", 1.5f);
    }

    public void up()
    {
        moveInput = new Vector2(0,1);
        animator.SetFloat("SpeedY", 1.5f);
    }

    public void stop()
    {
        moveInput = new Vector2(0,0);
        animator.SetFloat("SpeedX", 0f);
        animator.SetFloat("SpeedY", 0f);
    }


    public void OnInteract ()
    {
        if(canTalk != 0){
        interact = true;
        }
        
    }

    public bool getInteract()
    {
        return this.interact;
    }

    public int getTalk()
    {
        return this.canTalk;
    }

   
}

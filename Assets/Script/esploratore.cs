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
            SceneManager.LoadScene(6);
        }
       if (theCollision.gameObject.tag == "Png1")
       {
            canTalk = 1;
       }

        if (theCollision.gameObject.tag == "Png2")
        {
            canTalk = 2;
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
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
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

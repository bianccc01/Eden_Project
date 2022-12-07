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

    public Inventario inventario;


    private void Awake()
    {
        inventario = new Inventario(9);
    }

    
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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


    void OnInteract ()
    {
        
    }
}

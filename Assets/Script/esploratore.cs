using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class esploratore : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 0.1f;
    private Vector2 moveInput; 
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
            characterScale.x = 1;
        }

        if (moveInput.x < 0)
        {
            characterScale.x = -1;
        }

        transform.localScale = characterScale;

    }

   void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}

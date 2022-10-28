using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float bulletSpeed;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Transform playerTrasform = FindObjectOfType<Player>().transform;
        rb.velocity = transform.right * playerTrasform.localScale.x * bulletSpeed;
    }

    void FixedUpdate() {
        
    }

    void OntriggerEnter(Collision other) {

       print("Collisione avvenuta ");

       Destroy(this.gameObject);
    }

}

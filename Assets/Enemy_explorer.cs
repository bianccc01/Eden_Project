using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float moltiplicatoreDifficolta = 1f; //Temporaneo
    public float velocitaNemico;



    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(rb.position, player.transform.position, moltiplicatoreDifficolta * velocitaNemico * Time.fixedDeltaTime);

        Vector3 characterScale = transform.localScale;

        if (player.transform.position.x < transform.position.x)
        {
            characterScale.x = 0.75f;
        }

        if (player.transform.position.x > transform.position.x)
        {
            characterScale.x = -0.75f;
        }

        transform.localScale = characterScale;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float velocitaNemico;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
       rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(player);
        transform.position = Vector2.Lerp(rb.position,player.transform.position,velocitaNemico * Time.fixedDeltaTime);
    }
}

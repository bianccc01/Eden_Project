using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy_explorer : MonoBehaviour
{
    public Transform player;
    public Vector2 p1 = new Vector2(2.50f, -1f);
    public Vector2 p2 = new Vector2(6.36f, -1f);
    public Vector2 p3 = new Vector2(6.36f, -4.2f);
    public Vector2 p4 = new Vector2(2.50f, -4.2f);
    public Boolean pb1;
    public Boolean pb2;
    public Boolean pb3;
    public Boolean pb4;

    public float Distance;
    public float moltiplicatoreDifficolta = 1f; //Temporaneo
    public float velocitaNemico;



    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pb1 = true;
        pb2 = false;
        pb3 = false;
        pb4 = false;
    }

    // Update is called once per frame
    void Update()
    {
        float Px = player.transform.position.x;
        float Py = player.transform.position.y;
        float Ex = transform.position.x;
        float Ey = transform.position.y;

        // se il giocatore è più vicino di una certa distanza lo inseguo
        if ((Px - Ex) * (Px - Ex) + (Py - Ey) * (Py - Ey) < Distance)
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
        //quando il giocatore è più distante di un tot l'animale si muove in circolo su 4 punti 
        else
        {
            //se è appena stato nel punto 1 -> va nel punto 2
            if (pb1)
            {
                transform.position = Vector2.MoveTowards(rb.position, p2, velocitaNemico * Time.fixedDeltaTime);
                if (rb.position == p2)
                {
                    pb1 = false;
                    pb2 = true;
                }
            }

            if (pb2)
            {
                transform.position = Vector2.MoveTowards(rb.position, p3, velocitaNemico * Time.fixedDeltaTime);
                if (rb.position == p3)
                {
                    pb2 = false;
                    pb3 = true;
                }
            }

            if (pb3)
            {
                transform.position = Vector2.MoveTowards(rb.position, p4, velocitaNemico * Time.fixedDeltaTime);
                if (rb.position == p4)
                {
                    pb3 = false;
                    pb4 = true;
                }
            }

            if (pb4)
            {
                transform.position = Vector2.MoveTowards(rb.position, p1, velocitaNemico * Time.fixedDeltaTime);
                if (rb.position == p1)
                {
                    pb4 = false;
                    pb1 = true;
                }
            }
        }
    }
}
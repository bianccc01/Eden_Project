using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;



public class Lupo_explorer : MonoBehaviour
{ 
public Transform player;
public Vector2 p1;
public Vector2 p2;

public Boolean pb1;
public Boolean pb2;


public float Distance;
public float moltiplicatoreDifficolta = 1f; //Temporaneo
public float velocitaNemicoCamminata;
public float velocitaNemicoInseguimento;


Vector3 characterScale;



Rigidbody2D rb;


// Start is called before the first frame update
void Start()
{
    rb = GetComponent<Rigidbody2D>();
    pb1 = true;
    pb2 = false;


    characterScale = transform.localScale;
}

// Update is called once per frame
void Update()
{
    float Px = player.transform.position.x;
    float Py = player.transform.position.y;
    float Ex = transform.position.x;
    float Ey = transform.position.y;

    // se il giocatore e piu vicino di una certa distanza lo inseguo
    if ((Px - Ex) * (Px - Ex) + (Py - Ey) * (Py - Ey) < Distance)
    {
        transform.position = Vector2.Lerp(rb.position, player.transform.position, moltiplicatoreDifficolta * velocitaNemicoInseguimento * Time.fixedDeltaTime);

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
    //quando il giocatore ? pi? distante di un tot l'animale si muove in circolo su 4 punti 
    else
    {
        //se ? appena stato nel punto 1 -> va nel punto 2
        if (pb1)
        {
            voltaNemico(rb.position.x, p2);
            transform.position = Vector2.MoveTowards(rb.position, p2, velocitaNemicoCamminata * Time.fixedDeltaTime);
            if (rb.position == p2)
            {
                    new WaitForSeconds(3);
                pb1 = false;
                pb2 = true;
            }
        }

        if (pb2)
        {
            voltaNemico(rb.position.x, p1);
            transform.position = Vector2.MoveTowards(rb.position, p1, velocitaNemicoCamminata * Time.fixedDeltaTime);
            if (rb.position == p1)
            {
                    new WaitForSeconds(3);
                pb2 = false;
                pb1 = true;
            }
        }

    }
}


private void voltaNemico(float x, Vector2 p)
{
    if (x < p.x && characterScale.x == 0.75f)
    {
        characterScale.x = -0.75f;
        transform.localScale = characterScale;
    }

    if (x > p.x && characterScale.x == -0.75f)
    {
        characterScale.x = 0.75f;
        transform.localScale = characterScale;
    }
}
}
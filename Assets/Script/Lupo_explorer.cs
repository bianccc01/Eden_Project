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

public float time;

Vector3 characterScale;

Animator myAnimator;

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
    //quando il giocatore e piu' distante di un tot il lupo si aggira tra due punti 
    else
    {
        //se ? appena stato nel punto 1 -> va nel punto 2
        if (pb1)
        {
               if(time<3) {
                    time+= Time.deltaTime;
                }
else{
                voltaNemico(rb.position.x, p2);
            transform.position = Vector2.MoveTowards(rb.position, p2, velocitaNemicoCamminata * Time.fixedDeltaTime);

            if (rb.position == p2)
            {
        
                    scambia();
                    time=0;
            }
}
        }

        if (pb2)
        {
               if(time<3) {
                    time+= Time.deltaTime;
                }
else{
                voltaNemico(rb.position.x, p1);
            transform.position = Vector2.MoveTowards(rb.position, p1, velocitaNemicoCamminata * Time.fixedDeltaTime);
            if (rb.position == p1)
            {
                   
                    scambia();
                    time=0;
            }
}
        }

    }
}
    private void scambia()
    {
        if (pb1) pb1 = false;
        else pb1 = true;
        if (pb2) pb2 = false;
        else pb2 = true;
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
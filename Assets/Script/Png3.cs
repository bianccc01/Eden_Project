using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Png3 : MonoBehaviour
{

    public float time=0;
    public Vector2 p1;
    public Vector2 p2;
    public Vector2 p3;
    public Vector2 p4;
    public bool pb1;
    public bool pb2;
    public bool pb3;
    public bool pb4;
    Vector3 characterScale;

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

        characterScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("HasPistola")==1){
 if (pb1)
            {
                
                 if(time<3) {
                    time+= Time.deltaTime;
                }
                else{
                voltaNemico(rb.position.x, p2);
                transform.position = Vector2.MoveTowards(rb.position, p2, velocitaNemico * Time.fixedDeltaTime);
                if (rb.position == p2)
                {
                    pb1 = false;
                    pb2 = true;
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
                voltaNemico(rb.position.x, p3);
                transform.position = Vector2.MoveTowards(rb.position, p3, velocitaNemico * Time.fixedDeltaTime);
                if (rb.position == p3)
                {
                    pb2 = false;
                    pb3 = true;
                    time=0;
                }
                }
            }

            if (pb3)
            {
                 if(time<3) {
                    time+= Time.deltaTime;
                }
                else{
                voltaNemico(rb.position.x, p4);
                transform.position = Vector2.MoveTowards(rb.position, p4, velocitaNemico * Time.fixedDeltaTime);
                if (rb.position == p4)
                {
                    pb3 = false;
                    pb4 = true;
                    time=0;
                }
                }
            }

            if (pb4)
            {
                 if(time<3) {
                    time+= Time.deltaTime;
                }
                else{
                voltaNemico(rb.position.x, p1);
                transform.position = Vector2.MoveTowards(rb.position, p1, velocitaNemico * Time.fixedDeltaTime);
                if (rb.position == p1)
                {
                    pb4 = false;
                    pb1 = true;
                    time=0;
                }
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

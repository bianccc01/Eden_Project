using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{

    public esploratore player;

    public GameObject box1;
    public GameObject box2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.getTalk() == 1)
        {
            gameObject.SetActive(true);
            box1.SetActive(true);
        }

        if(player.getTalk() == 2)
        {
            gameObject.SetActive(true);
            box2.SetActive(true);
        }

        if(player.getTalk() == 0)
        {
            gameObject.SetActive(false);
            box1.SetActive(false);
            box2.SetActive(false);
        }
    }
}

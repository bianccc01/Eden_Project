using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{

    public esploratore player;

    public GameObject box1;
    public GameObject box2;
    public GameObject box3;
    public GameObject box4;
    public GameObject box5;


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

        if (player.getTalk() == 3)
        {
            gameObject.SetActive(true);
            box3.SetActive(true);
        }


        if (player.getTalk() == 5 && (PlayerPrefs.GetInt("HasPistola")!=1))
        {
            gameObject.SetActive(true);
            box5.SetActive(true);
             PlayerPrefs.SetInt("HasPistola",1);
        }

        if (player.getTalk() == 5 && (PlayerPrefs.GetInt("HasPistola")==1) && !box5.activeSelf)
        {
            gameObject.SetActive(true);
            box4.SetActive(true);
        }

        if(player.getTalk() == 0)
        {
            gameObject.SetActive(false);
            box1.SetActive(false);
            box2.SetActive(false);
            box3.SetActive(false);
            box4.SetActive(false);
            box5.SetActive(false);
        }
    }
}

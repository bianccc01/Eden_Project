using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InizializzazioniMappa : MonoBehaviour
{

    public GameObject exp;
    private float x;
    private float y;

    public GameObject wolf1;
    public GameObject wolf2;
    public GameObject wolf3;
    public GameObject cow;
    
    // Start is called before the first frame update
    void Start()
    {
        y=PlayerPrefs.GetFloat("PosizioneY");
        x=PlayerPrefs.GetFloat("PosizioneX");

        if(PlayerPrefs.GetInt("Nemico") != 0)
        exp.transform.position = new Vector2(x,y);

        if(PlayerPrefs.GetInt("Nemico") == 3)
        {
            wolf3.SetActive(false);
            PlayerPrefs.SetInt("CarneLupo",PlayerPrefs.GetInt("CarneLupo")+1);
        }

        if(PlayerPrefs.GetInt("Nemico") == 2)
        {
            wolf2.SetActive(false);
        }

        if(PlayerPrefs.GetInt("Nemico") == 1)
        {
            wolf1.SetActive(false);
        }

        if(PlayerPrefs.GetInt("Nemico") == 4)
        {
            cow.SetActive(false);
        }
       
    }

    // Update is called once per frame
    private void OnDisable() {
        
    }
}
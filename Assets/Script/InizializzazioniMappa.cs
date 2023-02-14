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

        if(PlayerPrefs.GetInt("Nemico1") == 1)
        exp.transform.position = new Vector2(x,y);

        if(PlayerPrefs.GetInt("Nemico3") == 0)
        {
            wolf3.SetActive(true);
            PlayerPrefs.SetInt("CarneLupo",PlayerPrefs.GetInt("CarneLupo")+1);
        }

        if(PlayerPrefs.GetInt("Nemico2") == 0)
        {
            wolf2.SetActive(true);
        }

        if(PlayerPrefs.GetInt("Nemico1") == 0)
        {
            wolf1.SetActive(true);
        }

        if(PlayerPrefs.GetInt("Nemico4") == 0)
        {
            cow.SetActive(true);
        }
       
    }

    // Update is called once per frame
    private void OnDisable() {
        
    }
}
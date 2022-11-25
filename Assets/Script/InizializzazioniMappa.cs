using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InizializzazioniMappa : MonoBehaviour
{

    public GameObject exp;
    public GameObject enemy;
    private float x;
    private float y;
    
    // Start is called before the first frame update
    void Start()
    {
        y=PlayerPrefs.GetFloat("PosizioneY");
        x=PlayerPrefs.GetFloat("PosizioneX");

        exp.transform.position = new Vector2(x,y);
       
        

        if(PlayerPrefs.GetInt("StatoNemico") == 0)
         enemy.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void OnDisable() {
        
    }
}
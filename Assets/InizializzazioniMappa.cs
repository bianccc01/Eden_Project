using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InizializzazioniMappa : MonoBehaviour
{

    public GameObject exp;
    private float x;
    private float y;
    
    // Start is called before the first frame update
    void Start()
    {
        y=PlayerPrefs.GetFloat("PosizioneY");
        x=PlayerPrefs.GetFloat("PosizioneX");
        Instantiate(exp,new Vector2 (x,y),transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

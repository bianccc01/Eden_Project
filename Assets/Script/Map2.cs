using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map2 : MonoBehaviour
{
    public GameObject exp;
    private float x;
    private float y;


    
    // Start is called before the first frame update
    void Start()
    {
        y=PlayerPrefs.GetFloat("PosizioneY");
        x=PlayerPrefs.GetFloat("PosizioneX");

        
        exp.transform.position = new Vector2(x,y);

      

        


        
       
    }

    // Update is called once per frame
    private void OnDisable() {
        
    }
}

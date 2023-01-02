using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPng2 : MonoBehaviour
{

    public esploratore esplorator;

    public DialogueScript2 dialogo;

    //public GameObject box;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((esplorator.getInteract()) && (esplorator.getTalk() == 2)){
            //box.SetActive(true);
            dialogo.activate();
        }
        
        else 
    {
        dialogo.setIndex(0);
        //box.SetActive(false);
        dialogo.disattiva();
    }
}
}

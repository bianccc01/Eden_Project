using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueBoxEnemy : MonoBehaviour
{

    public EnemyFight nemico;
    public GameObject box1;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(nemico.currentHealth==0)
        {
            gameObject.SetActive(true);
            box1.SetActive(true);
        }

    }
}

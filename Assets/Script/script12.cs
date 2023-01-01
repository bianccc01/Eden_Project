using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script12 : MonoBehaviour
{

    public esploratore esplorator;

    public DialogueScript dialogo;

    public GameObject box;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (esplorator.getInteract())
        {
            box.SetActive(true);
            dialogo.activate();
        }

        else
        {
            dialogo.setIndex(0);
            box.SetActive(false);
        }
    }
}
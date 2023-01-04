using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInventario : MonoBehaviour
{

    public GameObject pistola;
    public GameObject mitra;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("HasPistola") == 1)
        {
            pistola.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

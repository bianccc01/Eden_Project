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
        exp = Resourse.Load()
        Instantiate(exp,new Vector2 (x,y),transform.rotation);

        if(PlayerPrefs.GetInt("StatoNemico") == 1)
        Instantiate(enemy,new Vector2(-8,9),transform.rotation);
    }

    // Update is called once per frame
    private void OnDisable() {
        Destroy(enemy);
    }
}

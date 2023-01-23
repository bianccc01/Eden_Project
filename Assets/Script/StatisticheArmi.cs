using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // INCLUDO ANCHE QUESTA USING PER POTER USARE GLI OGGETTI IN QUESTIONE

public class StatisticheArmi : MonoBehaviour
{
    // Variabili per lo script
    TextMeshProUGUI Testo_Health;

    TextMeshProUGUI Testo_Ox;

    public static int ammo;



    // Use this for initialization


    void Start()
    {

        ammo = PlayerPrefs.GetInt("MunizioniPistola");

        
        // Accedo al componente testo del oggetto e uso il metodo SetText per impostare il testo
        Testo_Health = gameObject.GetComponent<TextMeshProUGUI>();
        Testo_Health.SetText(ammo+"                                              "+ammo);

    }
    // Update is called once per frame
    void Update()
    {
        // Per impostare il testo posso anche usare la propriet� text come per il testo di default
        
        

    






    }
}


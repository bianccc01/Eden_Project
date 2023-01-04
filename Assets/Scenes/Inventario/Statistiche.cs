using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // INCLUDO ANCHE QUESTA USING PER POTER USARE GLI OGGETTI IN QUESTIONE

public class Statistiche : MonoBehaviour
{
    // Variabili per lo script
    TextMeshProUGUI Testo_punteggio;

    TextMeshProUGUI Testo_Timer;

    public static int totalHealt;
    public static int actualHealt;

    // Use this for initialization


    void Start()
    {
        // Accedo al componente testo del oggetto e uso il metodo SetText per impostare il testo
        Testo_punteggio = gameObject.GetComponent<TextMeshProUGUI>();
        Testo_punteggio.SetText(" /");

    }
    // Update is called once per frame
    void Update()
    {
        // Per impostare il testo posso anche usare la proprietà text come per il testo di default
        CurrentAmmo = player.GetCurrentAmmo();
        TotalAmmo = player.GetTotalAmmo();

        if (TotalAmmo == -1)
        {
            Testo_punteggio.text = (" ");
        }

        else Testo_punteggio.text = CurrentAmmo.ToString() + "/" + TotalAmmo.ToString();






    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // INCLUDO ANCHE QUESTA USING PER POTER USARE GLI OGGETTI IN QUESTIONE

public class Statistiche : MonoBehaviour
{
    // Variabili per lo script
    TextMeshProUGUI Testo_Health;

    TextMeshProUGUI Testo_Ox;

    public static float totalHealt;
    public static float actualHealt;
    public static float actualRad;
    public static float actualOx;



    // Use this for initialization


    void Start()
    {

        totalHealt = PlayerPrefs.GetFloat("MaxHealth");
        actualHealt = PlayerPrefs.GetFloat("CurrentHealth");

        actualOx = PlayerPrefs.GetFloat("Ossigeno");
        actualRad = PlayerPrefs.GetFloat("Radioattivita");

        
        // Accedo al componente testo del oggetto e uso il metodo SetText per impostare il testo
        Testo_Health = gameObject.GetComponent<TextMeshProUGUI>();
        Testo_Health.SetText("Salute: " + (int)actualHealt+ " / " + (int)totalHealt + " \n \n" + "Ossigeno: " +  (int)actualOx + "% \n \n" +  "Radiazione: " + (int)actualRad + "%");

    }
    // Update is called once per frame
    void Update()
    {
        // Per impostare il testo posso anche usare la propriet� text come per il testo di default
        
        

    






    }
}


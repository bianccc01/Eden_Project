using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Narrazione3 : MonoBehaviour
{

    public TextMeshProUGUI textComponent;
    public string[] frase;
    public float textSpeed;
    private int index;

    
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text= string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
  
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (textComponent.text == frase[index])
                {
                    NextLine();
                }
                else
                {
                    StopAllCoroutines();
                    textComponent.text = frase[index];
                }
            }
        }


    void StartDialogue()
    {
        index = 0;
        StartCoroutine(Typeline());
    }

    IEnumerator Typeline()
    {
        foreach( char c in frase[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed); 
        }
    }


    void NextLine()
    {
        if (index < frase.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(Typeline());
        }
        else
        {
             PlayerPrefs.SetFloat("Ossigeno", 100f);
        PlayerPrefs.SetFloat("MaxHealth", 250f);
        PlayerPrefs.SetFloat("Radioattivita", 0);
        PlayerPrefs.SetFloat("CurrentHealth", 250f);

        PlayerPrefs.SetFloat("PosizioneY", 15f);
        PlayerPrefs.SetFloat("PosizioneX", -20f);

       PlayerPrefs.SetInt("Nemico",0);

       PlayerPrefs.SetInt("HasPistola",0);
       PlayerPrefs.SetInt("HasMitra",0);

       PlayerPrefs.SetInt("CarneLupo",0);

       PlayerPrefs.SetInt("MunizioniPistola",20);
       
       SceneManager.LoadScene(5);
        }
    }
    public void setIndex(int i)
    {
        this.index = i + 1;
        textComponent.text = frase[0];
    }

    public void activate()
    {
        gameObject.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Narrazione1 : MonoBehaviour
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
            SceneManager.LoadScene(11);
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

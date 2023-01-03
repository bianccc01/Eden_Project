using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueScript2 : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;


    public esploratore esplorator;

    public GameObject box;
    
    public bool attivo;

    public int index;


    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        } 
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(Typeline());
    }
    IEnumerator Typeline()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index<lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(Typeline());
        }
        else
        {
            this.index = 0;
            gameObject.SetActive(false);   
        }
    }

    public DialogueScript2 GetDialogue()
    {
        return this;
    }

    public void setIndex (int i)
    {
        this.index = i+1;
        textComponent.text = lines[0];
    }

    public void activate ()
    {
        gameObject.SetActive(true);
        box.SetActive(true);
    }

    public void disattiva()
    {
        gameObject.SetActive(false);
    }
}
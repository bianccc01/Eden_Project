using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_iniziale : MonoBehaviour
{
    public void Button_Registarzione_Indietro()
    {
        SceneManager.LoadScene(0);
    }

    public void Button_Play()
    {
        SceneManager.LoadScene(5);
    }

    public void Button_Opzioni()
    {
        SceneManager.LoadScene(3);
    }

    public void Button_Esci()
    {
        Application.Quit();
    }
    public void Button_Opzioni_Indietro()
    {
        SceneManager.LoadScene(2);
    }

    public void Button_Personaggio()
    {
        SceneManager.LoadScene(4);
    }

    public void Button_Per_Registrazione()
    {
        SceneManager.LoadScene(1);
    }


}

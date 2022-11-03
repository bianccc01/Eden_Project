using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_iniziale : MonoBehaviour
{

    public void Button_Play()
    {
        SceneManager.LoadScene(3);
    }

    public void Button_Opzioni()
    {
        SceneManager.LoadScene(1);
    }

    public void Button_Esci()
    {
        Application.Quit();
    }
    public void Button_Indietro()
    {
        SceneManager.LoadScene(0);
    }

    public void Button_Personaggio()
    {
        SceneManager.LoadScene(2);
    }


}

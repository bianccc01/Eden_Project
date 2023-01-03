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
        PlayerPrefs.SetFloat("Ossigeno", 100f);
        PlayerPrefs.SetFloat("MaxHealth", 250f);
        PlayerPrefs.SetFloat("CurrentHealth", 250f);

        PlayerPrefs.SetFloat("PosizioneY", 15f);
        PlayerPrefs.SetFloat("PosizioneX", -20f);

       PlayerPrefs.SetInt("StatoNemico",1);
       
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

    public void Button_GameOver_esci()
    {
        SceneManager.LoadScene(2);
    }


}
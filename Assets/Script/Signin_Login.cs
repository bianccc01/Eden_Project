using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;
using System;
using TMPro;
//using UnityEditor.PackageManager;
using Unity.VisualScripting;

public class Signin_Login : MonoBehaviour
{

    [Header("UI")]
    public TMP_Text messaggio;
    public TMP_InputField emailR;
    public TMP_InputField passwordR;
    public TMP_InputField usernameR;

    public void Button_Registrazione()
    {
        if (passwordR.text.Length < 6)
        {
            messaggio.text = "Password troppo corta! Inserisci " +
                "almeno 6 caratteri.";
            return;
        }

        if (usernameR.text.Length < 3 || usernameR.text.Length > 20)
        {
            messaggio.text = "Username non idoneo! Inserisci " +
                "tra i 3 ed i 20 caratteri alfabetici e numerici.";
            return;
        }

        var richiesta = new RegisterPlayFabUserRequest()
        {
            Email = emailR.text,
            Password = passwordR.text,
            Username = usernameR.text
        };
        PlayFabClientAPI.RegisterPlayFabUser(richiesta, OnRegisterSuccess, OnErrorRegister);
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        messaggio.text = "Ora sei registrato! Fai il login per iniziare!";
    }

    void OnErrorRegister(PlayFabError error)
    {
        messaggio.text = "Account non creato! Username o email gi� in uso.";
        Debug.Log($"Account non creato!\n {error.GenerateErrorReport()}");
    }

    public void Button_Login()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailR.text,
            Password = passwordR.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnErrorLogin);


    }

    void OnLoginSuccess(LoginResult result)
    {
        Debug.Log($"Log in");
        SceneManager.LoadScene(2);
    }

    void OnErrorLogin(PlayFabError error)
    {
        messaggio.text = "Email o password non corretti";
        Debug.Log($"Email o password non corretti!\n {error.GenerateErrorReport()}");
    }



    public void Button_Reset()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = emailR.text,
            TitleId = "7C914"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnErrorPassword);
    }

    void OnPasswordReset(SendAccountRecoveryEmailResult result)
    {
        messaggio.text = "Email per il reset password inviata!";
    }

    void OnErrorPassword(PlayFabError error)
    {
        messaggio.text = "Errore nell'invio della email. Per favore riprova!";
    }


}

using PlayFab.ClientModels;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variabili : MonoBehaviour
{

    public HealthBar Osbar;
    public Lifebar lifebar;
    public HealthBar Radiobar;


  void OnDisable() 
  { 
      PlayerPrefs.SetFloat("Ossigeno", Osbar.getHealth()); 
      PlayerPrefs.SetFloat("MaxHealth", lifebar.getMaxValue());
      PlayerPrefs.SetFloat("CurrentHealth",lifebar.getHealthLife());
      PlayerPrefs.SetFloat("Radioattivita", Radiobar.getHealth());
      

        PlayerPrefs.Save();
  }
   



}

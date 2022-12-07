using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventario_UI : MonoBehaviour
{

    public GameObject pannelloInventario;

    public esploratore player;

    public List<Slots_UI> slots = new List<Slots_UI>();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gestioneInventario();
        }
    }

    public void gestioneInventario()
    {
        if(!pannelloInventario.activeSelf)
        {
            pannelloInventario.SetActive(true);
            SetUp();
        }
        else
        {
            pannelloInventario.SetActive(false);
        }
    }

    public void SetUp()
    {
        if (slots.Count == player.inventario.slots.Count)
        {
            for(int i=0; i < slots.Count; i++)
            {
                if (player.inventario.slots[i].type != CollectableType.NONE)
                {
                    slots[i].SetItem(player.inventario.slots[i]);
                }
                else
                {
                    slots[i].SetEmpty();
                }
            }
        }

    }
}

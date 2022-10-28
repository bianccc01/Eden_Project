using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public Transform spawnPos;
    public GameObject bullet;

    public bool shoot = false;

    // Update is called once per frame
    void FixedUpdate()
    {

        if (shoot)
        {
            Instantiate(bullet, spawnPos.position, spawnPos.rotation);
            shoot = false;
        }
        
    }


    /*Left click*/
    void OnShoot()
    {
        shoot = true;
    }
}

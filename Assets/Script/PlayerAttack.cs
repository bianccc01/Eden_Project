using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public Transform spawnPos;
    public GameObject bullet;

    private float time = 1.5f;

    private float timeReload;

    private int bullets;

    public bool shoot = false;

    // Update is called once per frame
    void FixedUpdate()
    {

        time += Time.fixedDeltaTime;

        if (bullets == 6)
        {
            Reload();
            shoot = false;
        }

        if (shoot && bullets < 6)
        {
            Instantiate(bullet, spawnPos.position, spawnPos.rotation);
            bullets++;
            shoot = false;
        }
        
    }


    /*Left click*/
    void OnShoot()
    {
        if(time>=0.5f)
        {
            shoot = true;
            time = 0f;
        }
        
    }

    void Reload()
    {
        timeReload += Time.fixedDeltaTime;
        if(timeReload >= 3f)
        {
            bullets = 0;
            timeReload = 0;
            print("Reload finito !");
        }
    }
}

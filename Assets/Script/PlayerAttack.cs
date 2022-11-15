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

    private float timer;

    public int TotalAmmo = 20;

    public bool shoot = false;

    // Update is called once per frame
    void FixedUpdate()
    {

        time += Time.fixedDeltaTime;

        if (bullets == 6 && TotalAmmo > 0)
        {
            Reload();
            timer+=Time.fixedDeltaTime;
            shoot = false;
        }

        timer = 0f;

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
        if(timeReload >= 3f && TotalAmmo>=6)
        {
            bullets = 0;
            timeReload = 0;
            print("Reload finito !");
            TotalAmmo -=6;
        }

       else if(timeReload >= 3f && TotalAmmo > 0)
        {
            bullets = (6-TotalAmmo);
            timeReload = 0;
            print("Reload finito !");
            TotalAmmo = 0;
        }
    }


    public int GetCurrentAmmo()
    {
        return 6-this.bullets;
    }

    public int GetTotalAmmo()
    {
        return this.TotalAmmo;
    }

    public float GetTime()
    {
        return 3f-this.timer;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{

    public Transform spawnPos;
    public GameObject bullet;
    public GameObject pistola;
    public GameObject mitra;



    private float time = 1.5f;

    private float timeReload;

    private int bullets;

    private int MitraBullets;

    public int TotalAmmo = 20;

    public int TotalAmmoMitra = 100;

    public bool shoot = false;

    public int arma; //Tiene conto dell'arma che si sta utilizzando (0 = niente, 1 = pistola, 2 = mitra)

    private void Start() 
    {
        //appena inizia non si avrà nessuna arma
        arma = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        time += Time.fixedDeltaTime;

        if (bullets == 6 && TotalAmmo > 0 && arma==1)
        {
            Reload();
            shoot = false;
        }

        if (shoot && bullets < 6 && arma == 1)
        {
            Instantiate(bullet, spawnPos.position, spawnPos.rotation);
            bullets++;
            shoot = false;
        }


        if (Input.GetButton("Fire1") && MitraBullets < 15 && arma == 2 && time>=0.2f)
        {
            Instantiate(bullet, spawnPos.position, spawnPos.rotation);
            MitraBullets++;
            time = 0f;
        }

        if (MitraBullets == 15 && TotalAmmoMitra > 0 && arma==2)
        {
            print("Provo a ricaricare ");
            ReloadMitra();
        }

    }


    /*Left click*/
    void OnShoot()
    {

        if(time>=0.3f && arma == 1)
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

    
    void ReloadMitra()
    {
        timeReload += Time.fixedDeltaTime;
        if(timeReload >= 4f && TotalAmmoMitra>=15)
        {
            MitraBullets = 0;
            timeReload = 0f;
            print("Reload finito !");
            TotalAmmoMitra -=15;
        }

       else if(timeReload >= 4f && TotalAmmoMitra > 0)
        {
            MitraBullets = (6-TotalAmmoMitra);
            timeReload = 0;
            print("Reload finito !");
            TotalAmmoMitra = 0;
        }
    }


    /*Tasto R della tastiera*/
    public void OnSwitch()
    {
        if(arma == 0)
        {
            pistola.gameObject.SetActive(true);
            arma++;
        }

        else if(arma == 1)
        {
            pistola.gameObject.SetActive(false);
            mitra.gameObject.SetActive(true);
            arma++;
        }

        else if(arma == 2)
        {
            mitra.gameObject.SetActive(false);
            arma=0;
        }
    }


    public int GetCurrentAmmo()
    {

        if(arma==1)
        {
            return 6-this.bullets;
        }

        else if (arma == 2)
        {
            return 15-this.MitraBullets;
        }

        else return 0;
       
    }

    public int GetTotalAmmo()
    {

        if(arma==1)
        {
            return this.TotalAmmo;
        }
        
        else if (arma==2)
        {
            return this.TotalAmmoMitra;
        }

        else return -1;
    }
}

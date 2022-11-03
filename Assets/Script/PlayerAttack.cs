using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public Transform spawnPos;
    public GameObject bullet;

    private float time = 1.5f;

    public bool shoot = false;

    // Update is called once per frame
    void FixedUpdate()
    {

        time += Time.fixedDeltaTime;

        if (shoot)
        {
            Instantiate(bullet, spawnPos.position, spawnPos.rotation);
            shoot = false;
        }
        
    }


    /*Left click*/
    void OnShoot()
    {
        if(time>=1.5f)
        {
            shoot = true;
            time = 0f;
        }
        
    }
}

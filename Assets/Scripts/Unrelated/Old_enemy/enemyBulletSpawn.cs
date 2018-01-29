using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletSpawn : MonoBehaviour {

    public bool isFiring = false;

    public Bullet bullet;

    //public float bulletSpeed;
    public float timeBetweenShots;
    private float shotCounter = .2f;

    public Transform bulletSpawner;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        shotCounter -= Time.deltaTime;
        if (isFiring == true)
        {
            if (shotCounter <= 0)
            {
                shotCounter = .2f;
                Bullet newBullet = Instantiate(bullet, bulletSpawner.position, bulletSpawner.rotation) as Bullet;
            }
            /*   else
               {
                   shotCounter = 1;
               }
        */
        }

        if (Input.GetMouseButtonDown(0))
        {
            isFiring = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isFiring = false;
        }
    }
}

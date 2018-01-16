using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShooting : MonoBehaviour {

    public bool isFiring = false;

    public Bullet bullet;

    public AudioSource firingEffect;

    public float shotCounterWait = 3f;
    public float shotCounterUnleash = .2f;

    public Transform bulletSpawner;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        shotCounterWait -= Time.deltaTime;
        if (shotCounterWait >= 1.5)
        {
            shotCounterUnleash -= Time.deltaTime;
            if (shotCounterUnleash <= 0)
            {
                firingEffect.Play();
                Bullet newBullet = Instantiate(bullet, bulletSpawner.position, bulletSpawner.rotation) as Bullet;
                shotCounterUnleash = .2f;
            }
        }
        if (shotCounterWait <= 0)
        {
            shotCounterWait = 3f;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDeather : MonoBehaviour {

    public int hp = 3;

    SpriteRenderer sr;

    public Sprite dead;

    public Transform Explosion;

    public GameObject Parent;

    public float timeToExplode = .1f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (hp <= 0)
        {
            if (Parent.activeInHierarchy == true)
            {
                Instantiate(Explosion, transform.position, transform.rotation);
            }
            Parent.SetActive(false);
            //Changing the sprite 
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Bullet"))
        {
            hp--;
        }
    }
}

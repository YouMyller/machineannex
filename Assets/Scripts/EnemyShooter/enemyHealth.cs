using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour {

    public float hp = 5;

    private bool flashActive = false;

    public float flashLength;
    private float flashCounter;

    public SpriteRenderer enemySprite;

    public Transform Explosion;

    public GameObject parent;

    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (hp <= 0)
        {
            Instantiate(Explosion, transform.position, transform.rotation);
            Destroy(parent);
            Destroy(gameObject);
        }

        if (flashActive)
        {
            if (flashCounter > flashLength * .66f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .33f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
            }
            else if (flashCounter > 0f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
            }
            else
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
                flashActive = false;
            }
        }
        flashCounter -= Time.deltaTime;
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        //debug = true;
        if (col.CompareTag("Bullet"))
        {
            hp--;
            flashActive = true;
            flashCounter = flashLength;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Bullet"))
        {
            hp--;
            flashActive = true;
            flashCounter = flashLength;
        }
    }
}

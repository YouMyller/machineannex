using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour {

    //public Sprite[] HealthSprites;

    //public Image HeartUI;

    public GameObject h1, h2, h3, h4, h5;

    public int hp = 5;

    public bool flashActive = false;

    public float flashLength;
    private float flashCounter;

    public SpriteRenderer playerSprite;

    public Transform Explosion;



    // Use this for initialization
    void Start ()
    {
        playerSprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //HeartUI.sprite = HealthSprites[hp];

        if (hp == 8 || hp == 9)
        {
            h5.SetActive(false);
            h4.SetActive(false);
        }
        if (hp == 6 || hp == 7)
        {
            h4.SetActive(false);
            h3.SetActive(true);
        }
        if (hp == 5 || hp == 6)
        {
            h3.SetActive(false);
            h2.SetActive(true);
        }
        if (hp == 3 || hp == 4)
        {
            h2.SetActive(false);
            h1.SetActive(true);
        }
        if (hp == 1 || hp == 2)
        {
            h1.SetActive(false);
        }

        if (flashActive)
        {
            if (flashCounter > flashLength * .66f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .33f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > 0f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                flashActive = false;
            }
        }
        flashCounter -= Time.deltaTime;

        if (hp <= 0)
        {
            Instantiate(Explosion, transform.position, transform.rotation);
            SceneManager.LoadScene("gameover");
        }
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
        if (col.CompareTag("Child") || col.CompareTag ("Tank"))
        {
            SceneManager.LoadScene("gameover");
        }
    }
}

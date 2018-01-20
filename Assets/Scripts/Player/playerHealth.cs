using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour {

    //public Sprite[] HealthSprites;

    //public Image HeartUI;

    public GameObject h1, h2, h3, h4, h5;

    //public GameObject healthGUI;

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

        if ((hp == 8 || hp == 9) && h5.activeInHierarchy == true)
        {
            //healthGUI = h4;
            h5.SetActive(false);
            h4.SetActive(true);
        }
        if (hp == 6 || hp == 7 && h4.activeInHierarchy == true)
        {
            //healthGUI = h3;
            h4.SetActive(false);
            h3.SetActive(true);
        }
        if (hp == 4 || hp == 3 && h3.activeInHierarchy == true)
        {
            //healthGUI = h2;
            h3.SetActive(false);
            h2.SetActive(true);
        }
        if (hp == 2 || hp == 1 && h2.activeInHierarchy == true)
        {
            //healthGUI = h1;
            h2.SetActive(false);
            h1.SetActive(true);
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
        if (col.CompareTag("Child") || col.CompareTag ("Tank") || col.CompareTag("Melee"))
        {
            SceneManager.LoadScene("gameover");
        }
    }
}

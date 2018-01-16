using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorTrigger : MonoBehaviour {

    bool isTrue = false;
    //public GameObject nextInLine;

    private enemyHealth eHealth;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (isTrue == true)
        {
            Debug.Log("Köh");
            gameObject.SetActive(false);
            //nextInLine.SetActive(true);
        }
        if (eHealth.hp <= 0)    //Something else here
        {
            Debug.Log("Hurray!");
            isTrue = true;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isTrue = true;
        }
    }
}

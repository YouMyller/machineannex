using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathTest : MonoBehaviour {

    float deathTime = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        deathTime -= Time.deltaTime;
        
        if (deathTime <= 0)
        {
            SceneManager.LoadScene("gameover");
        }
	}

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("KAKKA");
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("gameover");
        }
    }*/
}

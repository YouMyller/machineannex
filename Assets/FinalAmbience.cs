using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalAmbience : MonoBehaviour {

    public GameObject soundManager;
    public AudioSource sound;
    public bool turnOn = false;

	// Use this for initialization
	void Start ()
    {
	    	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SoundTrigger" && turnOn == false)
        {
            soundManager.SetActive(true);
            Destroy(collision.gameObject);
            turnOn = true;
        }
        else if (collision.gameObject.tag == "SoundTrigger" && turnOn == true)
        {
            sound.volume = .7f;
            Destroy(collision.gameObject);
        }
    }
}

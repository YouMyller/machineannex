using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTrigger : MonoBehaviour {

    public GameObject door;
    bool going = false;

	// Use this for initialization
	void Start ()
    {
	    	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (going == true)
        {
            door.GetComponent<doorClose>().enabled = true;
            GetComponent<playerTrigger>().enabled = false;
            going = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            going = true;
        }
    }
}

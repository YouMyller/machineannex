using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextInLine : MonoBehaviour {

    public GameObject next;

    private enemyHealth eHealth;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (eHealth.hp <= 0)
        {
            next.GetComponent<enemyMover>().enabled = true;
        }
	}
}

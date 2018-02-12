using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagReverser : MonoBehaviour {

    public float timer = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (gameObject.tag == "Waiting")
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            gameObject.tag = "PathPoint";
            timer = 1;
        }
	}
}

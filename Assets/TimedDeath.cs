using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDeath : MonoBehaviour {

    public float timedDeath;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        timedDeath -= Time.deltaTime;

        if (timedDeath <= 0)
        {
            Destroy(gameObject);
        }
	}
}

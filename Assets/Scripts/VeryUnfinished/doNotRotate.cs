using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doNotRotate : MonoBehaviour {

    public Rigidbody myRigidbody;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        myRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorClose : MonoBehaviour {

    //public bool closed = false;
    public float moveTime = 1f;

    public float speed = .1f;

    private Rigidbody rb;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        moveTime -= Time.deltaTime;
	    //if (closed == false)
        //{
            if (moveTime > 0)
            {
                //Debug.Log("Liikkuminen");
                transform.Translate(Vector2.up * speed);
            }
            if (moveTime < 0)
            {
                //Destroy(gameObject);
                speed = 0f;
                //Debug.Log("höhö");
                rb.isKinematic = true;

            }
        //}
	}
}

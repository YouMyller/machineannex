using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endDoor : MonoBehaviour {

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
	    if (!GameObject.FindGameObjectWithTag("Melee"))
        {
            moveTime -= Time.deltaTime;
            if (moveTime > 0)
            {
                transform.Translate(Vector2.down * speed);
            }
            if (moveTime < 0)
            {
                //Destroy(gameObject);
                speed = 0f;
                rb.isKinematic = true;

            }
        }
	}
}

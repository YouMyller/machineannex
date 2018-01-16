using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phmove : MonoBehaviour {

    public float moveSpeed = 5;

    private Vector2 move;
    public Vector2 moveVelocity;

    public Rigidbody2D myRigidBody;

    // Use this for initialization
    void Start ()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        moveVelocity = move * moveSpeed;

        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        myRigidBody.velocity = moveVelocity;
    }
}

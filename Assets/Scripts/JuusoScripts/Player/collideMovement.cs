using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collideMovement : MonoBehaviour {

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
        myRigidBody.velocity = moveVelocity;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("UpDown Rail"))
        {
            MoveUpDown();
        }
        else if (col.gameObject.CompareTag("RightLeft Rail"))
        {
            MoveRightLeft();
        }
        else if (col.gameObject.CompareTag("FourDirections Rail"))
        {
            MoveFourDirections();
        }
    }

    void MoveUpDown()
    {
        move = new Vector2(move.x, Input.GetAxisRaw("Vertical"));
    }

    void MoveRightLeft()
    {
        move = new Vector2(Input.GetAxisRaw("Horizontal"), move.y);
    }

    void MoveFourDirections()
    {
        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = move * moveSpeed;
    }
}

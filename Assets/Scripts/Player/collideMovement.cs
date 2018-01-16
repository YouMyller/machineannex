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

    void Update()
    {
       //moveVelocity
    }

    // Update is called once per frame
    void FixedUpdate ()
    {

        moveVelocity = move * moveSpeed;
        myRigidBody.velocity = moveVelocity;
        //move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        //moveVelocity = move * moveSpeed;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        //debug = true;
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
        /*else if (col.gameObject.CompareTag("RightOnly Rail"))
        {
            MoveRightOnly();
        }
        else if (col.gameObject.CompareTag("LeftOnly Rail"))
        {
            MoveLeftOnly();
        }
        else if (col.gameObject.CompareTag("UpOnly Rail"))
        {
            MoveUpOnly();
        }
        else if (col.gameObject.CompareTag("DownOnly Rail"))
        {
            MoveDownOnly();
        }
        else if (col.gameObject.CompareTag("DownLeft Rail"))
        {
            MoveLeftDown();
        }
        else if (col.gameObject.CompareTag("UpRight Rail"))
        {
            MoveUpRight();
        }
        else if (col.gameObject.CompareTag("UpLeft Rail"))
        {
            MoveUpLeft();
        }
        else if (col.gameObject.CompareTag("DownRight Rail"))
        {
            MoveDownRight();
        }
        else if (col.gameObject.CompareTag("UpDownLeft Rail"))
        {
            MoveUpDownLeft();
        }
        else if (col.gameObject.CompareTag("UpLeftRight Rail"))
        {
            MoveUpLeftRight();
        }
        else if (col.gameObject.CompareTag("UpDownRight Rail"))
        {
            MoveUpDownRight();
        }
        else if (col.gameObject.CompareTag("DownRightLeft Rail"))
        {
            MoveDownRightLeft();
        }*/
    }

    void MoveUpDown()
    {
        move = new Vector2(move.x, Input.GetAxisRaw("Vertical"));
        //myRigidBody.constraints = RigidbodyConstraints2D.None;
        //myRigidBody.constraints = RigidbodyConstraints2D.FreezePositionX;
    }

    void MoveRightLeft()
    {
        //Debug.Log("KAKKA");
        move = new Vector2(Input.GetAxisRaw("Horizontal"), move.y);
        //myRigidBody.constraints = RigidbodyConstraints2D.None;
        //myRigidBody.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    void MoveFourDirections()
    {
        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //Find a way to constrain movement here, as well
        //myRigidBody.constraints = RigidbodyConstraints2D.None;
        moveVelocity = move * moveSpeed;
    }

    /*void MoveRightOnly()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            move = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
            moveVelocity = move * moveSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W))
        {
            move = new Vector2(0, 0);
            moveVelocity = new Vector2(0, 0);
            myRigidBody.velocity = Vector2.zero;
        }
    }
    void MoveLeftOnly()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            move = new Vector2(Input.GetAxisRaw("Horizontal"), move.y);
            moveVelocity = move * moveSpeed;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            move = new Vector2(0, 0);
            moveVelocity = new Vector2(0, 0);
            myRigidBody.velocity = Vector2.zero;
        }
    }
    void MoveUpOnly()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            move = new Vector2(0, Input.GetAxisRaw("Vertical"));
            moveVelocity = move * moveSpeed;
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            move = new Vector2(0, 0);
            moveVelocity = new Vector2(0, 0);
            myRigidBody.velocity = Vector2.zero;
        }
    }
    void MoveDownOnly()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            move = new Vector2(move.x, Input.GetAxisRaw("Vertical"));
            moveVelocity = move * moveSpeed;
        }
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A))
        {
            move = new Vector2(0, 0);
            moveVelocity = new Vector2(0, 0);
            myRigidBody.velocity = Vector2.zero;
        }
    }
    void MoveLeftDown()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            move = new Vector2(Input.GetAxisRaw("Horizontal"), move.y);
            moveVelocity = move * moveSpeed;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            move = new Vector2(move.x, Input.GetAxisRaw("Vertical"));
            moveVelocity = move * moveSpeed;
        }
    }
    void MoveUpRight()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            move = new Vector2(0, Input.GetAxisRaw("Vertical"));
            moveVelocity = move * moveSpeed;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            move = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
            moveVelocity = move * moveSpeed;
        }
    }
    void MoveUpLeft()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            move = new Vector2(0, Input.GetAxisRaw("Vertical"));
            moveVelocity = move * moveSpeed;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            move = new Vector2(Input.GetAxisRaw("Horizontal"), move.y);
            moveVelocity = move * moveSpeed;
        }
    }
    void MoveDownRight()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            move = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
            moveVelocity = move * moveSpeed;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            move = new Vector2(move.x, Input.GetAxisRaw("Vertical"));
            moveVelocity = move * moveSpeed;
        }
    }
    void MoveUpDownLeft()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            move = new Vector2(move.x, Input.GetAxisRaw("Vertical"));
            moveVelocity = move * moveSpeed;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            move = new Vector2(Input.GetAxisRaw("Horizontal"), move.y);
            moveVelocity = move * moveSpeed;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            move = new Vector2(0, 0);
            moveVelocity = new Vector2(0, 0);
            myRigidBody.velocity = Vector2.zero;
        }
    }
    void MoveUpLeftRight()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            move = new Vector2(Input.GetAxisRaw("Horizontal"), move.y);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            move = new Vector2(0, Input.GetAxisRaw("Vertical"));
            moveVelocity = move * moveSpeed;
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            move = new Vector2(0, 0);
            moveVelocity = new Vector2(0, 0);
            myRigidBody.velocity = Vector2.zero;
        }
    }
    void MoveUpDownRight()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            move = new Vector2(move.x, Input.GetAxisRaw("Vertical"));
            moveVelocity = move * moveSpeed;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            move = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
            moveVelocity = move * moveSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            move = new Vector2(0, 0);
            moveVelocity = new Vector2(0, 0);
            myRigidBody.velocity = Vector2.zero;
        }
    }
    void MoveDownRightLeft()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            move = new Vector2(Input.GetAxisRaw("Horizontal"), move.y);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            move = new Vector2(move.x, Input.GetAxisRaw("Vertical"));
            moveVelocity = move * moveSpeed;
        }
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A))
        {
            move = new Vector2(0, 0);
            moveVelocity = new Vector2(0, 0);
            myRigidBody.velocity = Vector2.zero;
        }
    }
    */
}

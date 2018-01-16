using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementAlt : MonoBehaviour {

    //Maybe put a place at the end where the player can only move away from

    public float moveSpeedo = 5;
    //public float turnSpeed = 5;
    private Vector2 move;
    public Vector2 moveVelocity;

    public bool debug = false;

    public Rigidbody2D myRigidBody;
    public BulletCreator bulletCreator;


    // Use this for initialization
    void Start ()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        moveVelocity = move * moveSpeedo;
        //moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

     /*   Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);
   */ }

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
        else if (col.gameObject.CompareTag("RightOnly Rail"))
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
    }

    void FixedUpdate()
    {
        myRigidBody.velocity = moveVelocity;
    }

    void MoveUpDown()
    {
        move = new Vector2(move.x, Input.GetAxisRaw("Vertical"));
        //myRigidBody.constraints = RigidbodyConstraints2D.None;
        //myRigidBody.constraints = RigidbodyConstraints2D.FreezePositionX;
    }

    void MoveRightLeft()
    {
        move = new Vector2(Input.GetAxisRaw("Horizontal"), move.y);
        //myRigidBody.constraints = RigidbodyConstraints2D.None;
        //myRigidBody.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    void MoveFourDirections()
    {
        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //Find a way to constrain movement here, as well
        //myRigidBody.constraints = RigidbodyConstraints2D.None;
        moveVelocity = move * moveSpeedo;
    }
    void MoveRightOnly()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            move = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
            moveVelocity = move * moveSpeedo;
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
            moveVelocity = move * moveSpeedo;
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
            moveVelocity = move * moveSpeedo;
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
            moveVelocity = move * moveSpeedo;
        }
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A))
        {
            move = new Vector2(0, 0);
            moveVelocity = new Vector2(0, 0);
            myRigidBody.velocity = Vector2.zero;
        }
    }
    
}

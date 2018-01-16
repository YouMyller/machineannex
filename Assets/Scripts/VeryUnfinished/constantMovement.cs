using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class constantMovement : MonoBehaviour {

    //x is sideways, y is up, z is nowhere
    //float dir = 0;
    float choice = 0;
    //1 = up, 2 = down, 3 = right, 4 = left, 0 = beginning (up)
    //public float moveSpeedo = 2;

    private Vector2 move;
    public Vector2 moveVelocity;

    private Rigidbody2D myRigidBody;
    public BulletCreator bulletCreator;

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (choice != 1 || choice != 2 || choice != 3 || choice != 4)
        {
            transform.position += Vector3.up * Time.deltaTime * 4;
        }
        /* //Hit the Choice Zone -> make a choice. Once choice has been made, it comes into fruition in the Action Zone.
         if (dir == 0)
         {
             transform.position += Vector3.up * Time.deltaTime * 4;
             //transform.Translate(moveSpeedo, .08f, 0);  This won't work, because the rotation script is fucking with it
         }
         if (dir == 1)
         {
             transform.position += Vector3.down * Time.deltaTime * 4;
         }
         if (dir == 3)
         {
             transform.position += Vector3.right * Time.deltaTime * 4;
         }
         if (dir == 4)
         {
             transform.position += Vector3.left * Time.deltaTime * 4;
         }
   */
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Choice RightLeft"))
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log("Right!!");
                choice = 3;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                choice = 4;
            }
        }
        else if (col.CompareTag("Choice Right"))
        {
            choice = 3;
        }
        else if (col.CompareTag("Choice Left"))
        {
            choice = 4;
        }
        else if (col.CompareTag("Choice UpDown"))
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                choice = 1;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                choice = 2;
            }
        }
        else if (col.CompareTag("Choice Up"))
        {
            choice = 1;
        }
        else if (col.CompareTag("Choice Down"))
        {
            choice = 2;
        }
        else if (col.CompareTag("Action Zone"))
            //Aina alkuun Action Zone
        {
            if (choice == 1)
            {
                transform.position += Vector3.up * Time.deltaTime * 4;
            }
            if (choice == 2)
            {
                transform.position += Vector3.down * Time.deltaTime * 4;
            }
            if (choice == 3)
            {
                transform.position += Vector3.right * Time.deltaTime * 4;
            }
            if (choice == 4)
            {
                transform.position += Vector3.left * Time.deltaTime * 4;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLooking : MonoBehaviour {

    public float turnSpeed = 5;
    private Rigidbody2D myRigidBody;

    public enemyShooting bulletOutPooper;

    public GameObject playerObject;


    // Use this for initialization
    void Start ()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //playerObject = GameObject.FindGameObjectsWithTag("Player");
        //Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Vector2 direction = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    public float moveSpeed = 5;
    public float turnSpeed = 5;
    private Rigidbody2D myRigidBody;

    private Vector2 moveInput;
    private Vector2 moveVelocity;

    public BulletCreator bulletCreator;

	void Start ()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput * moveSpeed;

        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);

    }

    void FixedUpdate()
    {
        myRigidBody.velocity = moveVelocity;
    }
}

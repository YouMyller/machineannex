using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RammerAttack : MonoBehaviour {

    public Transform player;
    public float turnSpeed = 5;
    public float runSpeed = .1f;

    public Rigidbody rb;

    //Vector2 dir;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
	    if (Vector2.Distance(player.position, transform.position) < 20)
        {
            //Vector2 dir = player.position - transform.position;
            //dir.z = 0;

            Vector2 dir = player.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);

            rb.MovePosition(transform.position + transform.up * runSpeed * Time.smoothDeltaTime);
            //transform.Translate(runSpeed, 0, 0);

            /*if (dir.magnitude > 5)
            {
                transform.Translate(0, 0, .05f);
            }*/
        }
	}
}

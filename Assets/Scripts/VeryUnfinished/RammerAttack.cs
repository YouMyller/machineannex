using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RammerAttack : MonoBehaviour {

    public Transform player;
    private Transform target;

    public float turnSpeed = 5;
    public float runSpeed = .1f;
    private float aggroRange = 20;
    private float hitTimer = 2;

    public Rigidbody rb;

    private Ray Sight;

    private bool hitting = false;
    private bool turning = true;
    private bool moving = false;

    //Vector2 dir;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Sight.origin = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Sight.direction = transform.right;
        RaycastHit hit;

        if (Vector2.Distance(player.position, transform.position) < aggroRange)
        {
            //Vector2 dir = player.position - transform.position;
            //dir.z = 0;
            //Debug.Log(Vector2.Distance(player.position, transform.position));

            if (turning == true)
            {
                Vector2 dir = player.position - transform.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);
                Debug.DrawRay(Sight.origin, transform.right * aggroRange, Color.red);
            }

            if (Physics.Raycast(Sight, out hit, aggroRange))
            {
                // Debug.DrawRay(Sight.origin, transform.right * aggroRange, Color.red);
                // print(hit.collider.tag);
                if (hit.collider.tag == "Player")
                {
                    target = hit.transform;

                    turning = false;
                    moving = true;
                    //rb.MovePosition(transform.position + transform.up * runSpeed * Time.smoothDeltaTime);
                }
            }

            if (moving == true)
            {
                //transform.position = Vector3.MoveTowards(transform.position, target.position, runSpeed);
                transform.Translate(runSpeed, 0, 0);

                if (transform.position == target.position)  //Millä saa träkkäämään sitä positiota, jossa pelaaja oli sillä hetkellä kun Raycast osui?
                    //Yksi vaihtoehto voisi olla, että rammeri luo näkymättömän objektin osumakohtaan ja lähtee sitten sitä kohti.
                {
                    Debug.Log("Noice, nyt oot siellä");
                    if (hitting == false)
                    {
                        turning = true;
                    }
                }
            }

            //rb.MovePosition(transform.position + transform.up * runSpeed * Time.smoothDeltaTime);

            //transform.Translate(runSpeed, 0, 0);

            /*if (dir.magnitude > 5)
            {
                transform.Translate(0, 0, .05f);
            }*/
        }
        /*if (hitTimer <= 0)
        {
        SILLON KUN ON TRANSFORMISSA TAI JOTAIN
            hitting = false;
            hitTimer = 2;
        }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hitting = true;
        }
    }
}

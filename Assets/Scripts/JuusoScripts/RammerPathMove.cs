using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RammerPathMove : MonoBehaviour {

    private Ray Sight;

    public Transform[] Waypoints;

    private Transform rotateTo;
    public Transform player;

    public GameObject targetObject;

    public float runSpeed;
    public float turnSpeed;
    private float aggroRange = 5;
    float distanceTravelled;
    float distance;

    public int currentWP;

    private bool playerHunt = false;
    private bool travDistCount = false;
    private bool moving = false;

    Vector2 lastPosition;

    // Use this for initialization
    void Start()
    {
        currentWP = 0;
        transform.position = Waypoints[currentWP].position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moving == true)
        {
            transform.Translate(runSpeed, 0, 0);
        }

        if (Vector2.Distance(player.position, transform.position) < aggroRange)
        {
            Sight.origin = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Sight.direction = transform.right;
            RaycastHit hit;

            Vector2 dir = player.position - transform.position;

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);

            Debug.DrawRay(Sight.origin, transform.right * aggroRange, Color.red);

            if (Physics.Raycast(Sight, out hit, aggroRange))
            {
                if (hit.collider.tag == "Player")
                {
                    moving = true;
                    //search = false;
                    //rotateTo = player;

                    if (!targetObject.activeInHierarchy)
                    {
                        Instantiate(targetObject, player.position, transform.rotation);

                        //turning = false;
                        travDistCount = true;
                        distance = Vector2.Distance(transform.position, targetObject.transform.position);
                    }
                    if (targetObject.activeInHierarchy)
                    {
                        Destroy(targetObject);
                    }
                }
            }
            if (travDistCount == true)
            {
                distanceTravelled += Vector2.Distance(transform.position, lastPosition);
                lastPosition = transform.position;

                transform.Translate(runSpeed, 0, 0);
                //Debug.Log(distanceTravelled);

                if (distanceTravelled >= distance + 2)  //Lisättyyn lukuun vähän randomiutta
                {
                    moving = false;
                    distanceTravelled = 0;
                    travDistCount = false;
                }
            }
        }
        else
        {
            if (transform.position == Waypoints[currentWP].position)
            {
                currentWP++;
            }
            if (currentWP >= Waypoints.Length)
            {
                currentWP = 1;
            }
            transform.position = Vector3.MoveTowards(transform.position, Waypoints[currentWP].position, 5 * Time.deltaTime);
        }
    }

    public void FindNearestPath()
    {
        float minDist = Mathf.Infinity;
        Transform tMin = null;

        foreach (Transform wayPoint in Waypoints)
        {
            float dist = Vector2.Distance(transform.position, wayPoint.position);

            if (dist < minDist)
            {
                tMin = wayPoint;
                rotateTo = tMin;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            FindNearestPath();
        }
    }
}

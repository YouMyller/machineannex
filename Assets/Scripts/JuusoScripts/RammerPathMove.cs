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
    private float aggroRange = 8;
    float distanceTravelled;
    float distance;
    private float timeWithoutPath = 3;

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
        rotateTo = Waypoints[currentWP + 1];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 dir = rotateTo.position - transform.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);

        if (moving == true)
        {
            transform.Translate(runSpeed, 0, 0);
        }

        if (Vector2.Distance(player.position, transform.position) < aggroRange)
        {
            rotateTo = player;

            Sight.origin = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Sight.direction = transform.right;
            RaycastHit hit;

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
        else if (Vector2.Distance(player.position, transform.position) > aggroRange)
        {
            if (transform.position == Waypoints[currentWP].position)
            {
                timeWithoutPath = 3;
                currentWP++;
            }
            if (currentWP >= Waypoints.Length)
            {
                currentWP = 1;
            }
            transform.position = Vector3.MoveTowards(transform.position, Waypoints[currentWP].position, 5 * Time.deltaTime);
            rotateTo = Waypoints[currentWP];

            /*if (transform.position != Waypoints[currentWP].position)
            {
                timeWithoutPath -= Time.deltaTime;
            }

            if (timeWithoutPath <= 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, Waypoints[currentWP].position, 5 * Time.deltaTime);
            }*/
        }

        /*else
        {
            Debug.Log("No player, no path.");
            FindNearestPath();
            Vector2 dir = player.position - transform.position;

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);

            transform.Translate(runSpeed, 0, 0);
        }*/
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
            //FindNearestPath();
        }
    }
}

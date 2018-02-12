using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RammerAttack : MonoBehaviour {

    public Transform player;
    //private Transform target;
    private Transform rotateTo;

    Vector3 targetV;

    public float turnSpeed = 5;
    public float runSpeed = .1f;
    private float aggroRange = 10;
    private float hitTimer = 2;

    public Rigidbody rb;

    private Ray Sight;

    private bool hitting = false;
    private bool turning = true;
    private bool moving = false;
    private bool search = true;

    public GameObject targetObject;

    float distance;
    float distanceTravelled;
    float wallDistance;

    Vector2 lastPosition;

    //public Transform[] paths;
    public List<Transform> paths = new List<Transform>();

    //private Transform tMin;

    // Use this for initialization
    void Start ()
    {
        lastPosition = transform.position;
        //rotateTo = player;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Sight.origin = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Sight.direction = transform.right;
        RaycastHit hit;

        if (turning == true)
        {
            FindRotateTo();
            Vector2 dir = rotateTo.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);

            transform.Translate(runSpeed, 0, 0);

            if (Vector2.Distance(rotateTo.position, transform.position) < aggroRange)   //player.position
            {
                Debug.DrawRay(Sight.origin, transform.right * aggroRange, Color.red);

                if (Physics.Raycast(Sight, out hit, aggroRange))
                {
                    if (hit.collider.tag == "Player")
                    {
                        search = false;
                        rotateTo = player;

                        if (!targetObject.activeInHierarchy)
                        {
                            Instantiate(targetObject, rotateTo.position, transform.rotation);

                            turning = false;
                            moving = true;
                            distance = Vector2.Distance(transform.position, targetObject.transform.position);
                        }
                        if (targetObject.activeInHierarchy)
                        {
                            Destroy(targetObject);
                        }
                    }
                }
            }
        }
        if (moving == true)
        {
            distanceTravelled += Vector2.Distance(transform.position, lastPosition);
            lastPosition = transform.position;

            transform.Translate(runSpeed, 0, 0);
            //Debug.Log(distanceTravelled);

            if (distanceTravelled >= distance + 2)  //Lisättyyn lukuun vähän randomiutta
            {
                moving = false;
                if (hitting == false)
                {
                    turning = true;
                }
            }
        }
    }

    public void FindRotateTo()
    {
        if (turning == true && search == true)
        {
            float minDist = Mathf.Infinity;
            Transform tMin = null;

            foreach (Transform pathPoint in paths)
            {
                float dist = Vector2.Distance(transform.position, pathPoint.position);

                if (dist < minDist)
                {
                    tMin = pathPoint;
                    rotateTo = tMin;
                    
                    //if level 1, x amount of things, on level 2 y amount of things
                    if (rotateTo.tag == "Waiting")
                    {
                        if (pathPoint == paths[0])
                        {
                            tMin = paths[1];
                            rotateTo = tMin;
                        }
                        else if (pathPoint == paths[1])
                        {
                            tMin = paths[2];
                            rotateTo = tMin;
                        }
                        else if (pathPoint == paths[2])
                        {
                            tMin = paths[1];
                            rotateTo = tMin;
                        }
                        else if (pathPoint == paths[3])
                        {
                            tMin = paths[0];
                            rotateTo = tMin;
                        }
                        else if (pathPoint == paths[4])
                        {
                            tMin = paths[0];
                            rotateTo = tMin;
                        }
                        else if (pathPoint == paths[5])
                        {
                            tMin = paths[0];
                            rotateTo = tMin;
                        }
                        else if (pathPoint == paths[6])
                        {
                            tMin = paths[1];
                            rotateTo = tMin;
                        }
                    }

                    minDist = dist;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hitting = true;
        }
        if (collision.gameObject.tag == "Wall")
        {
            MoveToPoint();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PathPoint")
        {
            other.gameObject.tag = "Waiting";
        }
    }

    public void MoveToPoint()
    {
        float minDist = Mathf.Infinity;
        Transform tMin = null;

        foreach (Transform pathPoint in paths)
        {
            float dist = Vector2.Distance(transform.position, pathPoint.position);

            if (dist < minDist)
            {
                tMin = pathPoint;
                rotateTo = tMin;

                minDist = dist;
            }
        }
    }
}

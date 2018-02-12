using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RammerAggro : MonoBehaviour {

    private Ray Sight;

    public Transform player;
    private Transform rotateTo;

    Vector2 rotateToV; 

    public List<Transform> paths = new List<Transform>();   //Couldn't these be just turned into game objects instead? Then I could check for their collision or someting

    public GameObject targetObject;

    public float turnSpeed = 5;
    public float runSpeed = .1f;
    private float aggroRange = 10;
    float distance;

    private bool findPlayer = true;
    private bool findPath = false;
    private bool runToPath = false;

    private Rigidbody rb;

    //1. Enemy rotates towards the Player. 	
    //2. Checks if there is wall w/ raycast.
    //3. If there is a wall, rotate towards & move to the nearest path point.
    //4. Once at path point, check if player is within sight w/ raycast.
    //5. If player is withing sight, ATTACK!
    //6. Rinse and repeat.

    // Use this for initialization
    void Start ()
    {
        rotateTo = player;
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Sight.origin = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Sight.direction = transform.right;
        RaycastHit hit;

        rotateToV = new Vector2(rotateTo.position.x, rotateTo.position.y);

        Vector2 dir = rotateTo.position - transform.position;

        if (findPlayer == true)
        {
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);

            if (Physics.Raycast(Sight, out hit, aggroRange))
            {
                if (hit.collider.tag == "Player")
                {
                    //search = false;
                    rotateTo = player;
                    //transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), rotateToV, 3 * Time.deltaTime);
                    //The above should be done with physics
                    //transform.Translate(runSpeed, 0, 0);
                    rb.AddRelativeForce(dir.normalized * runSpeed, ForceMode.Force);    //EI TOIMI

                    if (!targetObject.activeInHierarchy)
                    {
                        Instantiate(targetObject, rotateTo.position, transform.rotation);

                        //turning = false;
                        //moving = true;
                        distance = Vector2.Distance(transform.position, targetObject.transform.position);
                    }
                    if (targetObject.activeInHierarchy)
                    {
                        Destroy(targetObject);
                    }
                }
                if (hit.collider.tag == "Wall")
                {
                    findPlayer = false;
                    findPath = true;
                }
            }
        }

        if (findPath == true)
        {
            FindRotateTo();
            Debug.Log(rotateTo);
            runToPath = true;
            findPath = false;
        }

        if (runToPath == true)
        {
            //transform.Translate(runSpeed, 0, 0);
            //Vector2 rotateToV = new Vector2(rotateTo.position.x, rotateTo.position.y);
            //transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), rotateToV, 3 * Time.deltaTime);
            //The above, but with physics
            rb.AddRelativeForce(dir.normalized * runSpeed, ForceMode.Force);    //EI TOIMI
        }
    }

    public void FindRotateTo()
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
                    if (rotateTo.tag == "Waiting")  //Can I not check whether my transform is the same as one of the points'?
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
                            tMin = paths[2];
                            rotateTo = tMin;
                        }
                        else if (pathPoint == paths[4])
                        {
                            tMin = paths[3];
                            rotateTo = tMin;
                        }
                    }

                    minDist = dist;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PathPoint")    
        {
            other.gameObject.tag = "Waiting";   
        }
        if (other.gameObject.tag == "Waiting")    
        {
            runToPath = false;
            findPlayer = true;
            Debug.Log("Oooooh boy, time to run!");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "PathPoint")
        {
            other.gameObject.tag = "Waiting";
        }
        if (other.gameObject.tag == "Waiting")
        {
            runToPath = false;
            findPlayer = true;
            Debug.Log("Oooooh boy, time to run!");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            FindRotateTo();
        }
    }
}

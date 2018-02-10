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

    public GameObject targetObject;

    float distance;
    float distanceTravelled;
    float wallDistance;

    Vector2 lastPosition;

    public Transform[] paths;

    //Vector2 dir;

    // Use this for initialization
    void Start ()
    {
        lastPosition = transform.position;
        rotateTo = player;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Sight.origin = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Sight.direction = transform.right;
        RaycastHit hit;

            //Vector2 dir = player.position - transform.position;
            //dir.z = 0;
            //Debug.Log(Vector2.Distance(player.position, transform.position));

        if (turning == true)
        {
            Vector2 dir = rotateTo.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);

            transform.Translate(runSpeed, 0, 0);

            /*GameObject[] walls = GameObject.FindGameObjectsWithTag("KillerWall");

            foreach (GameObject wallObj in walls)
            {
                wallDistance = Vector2.Distance(transform.position, wallObj.transform.position);
            }*/

            //wallDistance = Vector2.Distance(transform.position, GameObject.FindGameObjectsWithTag("KillerWall").transform.position);

            //Vihollisen pitäis varmaan myös tyyliin kääntyä vähän eri suuntaan kun "törmää" seinään??
            //Tai sitten pistetään vaan meneen jotain valmiiksi asetettua polkua pitkin... but that's kinda boring
            //Tai sitten vähän yhdistellä molempia; jos törmää seinään, ohjataan polulle

            if (Vector2.Distance(player.position, transform.position) < aggroRange)
            {
                Debug.DrawRay(Sight.origin, transform.right * aggroRange, Color.red);

                if (Physics.Raycast(Sight, out hit, aggroRange))
                {
                    // Debug.DrawRay(Sight.origin, transform.right * aggroRange, Color.red);
                    // print(hit.collider.tag);
                    if (hit.collider.tag == "Player")
                    {
                        if (!targetObject.activeInHierarchy)
                        {
                            Instantiate(targetObject, player.position, transform.rotation);
                            //targetV = new Vector3(targetObject.transform.position.x, targetObject.transform.position.y, targetObject.transform.position.z);
                            //target = targetObject.transform;

                            turning = false;
                            moving = true;
                            distance = Vector2.Distance(transform.position, targetObject.transform.position);
                        }
                        if (targetObject.activeInHierarchy)
                        {
                            Destroy(targetObject);
                        }
                        //rb.MovePosition(transform.position + transform.up * runSpeed * Time.smoothDeltaTime);
                    }
                    //if doesn't find player, goes to the MoveToPoint method
                }
            }

            if (moving == true)
            {
                //Debug.Log(target.position);
                //transform.position = Vector3.MoveTowards(transform.position, target.position, runSpeed);
                //distance = Vector2.Distance(transform.position, targetObject.transform.position);   //TÄMÄ JONNEKIN MUUALLE, MUUTEN EI TOIMI. SAA TAPAHTUA VAIN KERRAN!

                distanceTravelled += Vector2.Distance(transform.position, lastPosition);
                lastPosition = transform.position;

                //Debug.Log("Dist: " + distance);
                //Debug.Log("Dist travelled: " + distanceTravelled);

                transform.Translate(runSpeed, 0, 0);

                if (distanceTravelled >= distance + 2)
                    //Yksi vaihtoehto voisi olla, että rammeri luo näkymättömän objektin osumakohtaan ja lähtee sitten sitä kohti.
                {
                    moving = false;
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
        if (collision.gameObject.tag == "Wall")
        {
            MoveToPoint();
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
        //Stop this from looping (?), make go to next point by checking with raycast
    }
}

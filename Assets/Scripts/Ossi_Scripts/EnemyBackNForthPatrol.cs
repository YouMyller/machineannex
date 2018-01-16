using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBackNForthPatrol : MonoBehaviour {
    public Transform[] Waypoints;
    public float Speed;
    public int currentWP;
    public bool goPatrol = true;
    private bool goBack = false;
    public Vector3 Target;
    public Vector3 MoveDirection;
    public Vector3 Velocity;
    // Use this for initialization
    void Start ()
    {
        currentWP = 0;
        transform.position = Waypoints[currentWP].position;
	}
	// Update is called once per frame
	void Update ()

    {
        if (currentWP >= (Waypoints.Length-1))
        {
            goBack = true;
        }
        if (transform.position == Waypoints[currentWP].position)
        {
            if (goBack)
                currentWP--;
            else
                currentWP++;
        }

        else if(currentWP == 0)
        {
            goBack = false;
        }
        transform.position = Vector3.MoveTowards(transform.position, Waypoints[currentWP].position, Speed * Time.deltaTime);
    }
}

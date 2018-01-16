using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] Waypoints;
    public float Speed;
    public int currentWP;
    // Use this for initialization
    void Start()
    {
        currentWP = 0;
        transform.position = Waypoints[currentWP].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == Waypoints[currentWP].position)
        {
                currentWP++;
        }
        if (currentWP >= Waypoints.Length)
        {
            currentWP = 0;
        }
        transform.position = Vector3.MoveTowards(transform.position, Waypoints[currentWP].position, Speed * Time.deltaTime);
    }
}

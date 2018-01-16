using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMover : MonoBehaviour {

    public float distanceAway;
    public float speed;

    public Transform thisObject;
    public Transform target;
    //private NavMeshSurfaceAgentTests navComponent;
    private NavMeshAgent navComponent;

	// Use this for initialization
	void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        navComponent = this.gameObject.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        float dist = Vector3.Distance(target.position, transform.position);	

        if (target)
        {
            navComponent.SetDestination(target.position);
        }
        else
        {
            if (target == null)
            {
                target = this.gameObject.GetComponent<Transform>();
            }
            else
            {
                target = GameObject.FindGameObjectWithTag("Player").transform;
            }
        }
	}
}

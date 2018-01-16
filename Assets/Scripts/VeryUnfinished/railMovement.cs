using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class railMovement : MonoBehaviour {

    private Transform[] nodes;

	// Use this for initialization
	void Start ()
    {
        nodes = GetComponentsInChildren<Transform>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDrawGizmos()
    {
        for (int i = 0; i < nodes.Length - 1; i++)
        {
          //  Handles.DrawDottedLine(nodes[i]).position, nodes[i+1].position, 3.0f);
        }
    }

}

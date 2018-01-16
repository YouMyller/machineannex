using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerDoor : MonoBehaviour {

    public GameObject triggerObject;
    public GameObject enemyGroup;

    public float spawnTimer = 1f;

    public float speed = .1f;
    public float moveTime = 1f;
    //public int moveup, movedown, moveright, moveleft;

    private Rigidbody rb;

	// Use this for initialization
	void Start ()
    {
	    rb = GetComponent<Rigidbody>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!triggerObject.activeInHierarchy || !triggerObject)
        {
            spawnTimer -= Time.deltaTime;
            //Debug.Log("Hui");
            //if (enemyGroup.activeInHierarchy == true) //(enemyGroup.GetComponent<enemyMover>().enabled == false) //jotain lisää ehtoja
            Debug.Log("Jotain täennkin");
            //enemyGroup.SetActive(true);
            moveTime -= Time.deltaTime;
            if (moveTime > 0)
            {
                Debug.Log("Liikkuminen");
                transform.Translate(Vector2.up * speed);
            }
            if (moveTime < 0)
            {
                //Destroy(gameObject);
                speed = 0f;
                rb.isKinematic = true;
                Debug.Log("höhö");
                
            }
            if (spawnTimer <= 0)
            {
                enemyGroup.GetComponent<enemyMover>().enabled = true;
            }
        }
	}
}

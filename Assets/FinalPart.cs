using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPart : MonoBehaviour {

    public float spawnTime = 10;
    public bool spawner = false;
    public GameObject[] spawnedEnemies;
    public GameObject[] movedDoors;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (spawner == true)
        {
            spawnTime -= Time.deltaTime;
        }
        if (spawnTime <= 8 && spawnTime >= 6)
        {
            spawnedEnemies[0].GetComponent<enemyMover>().enabled = true;
        }
        if (spawnTime <= 6 && spawnTime >= 4)
        {
            spawnedEnemies[1].GetComponent<enemyMover>().enabled = true;
            movedDoors[0].GetComponent<moveDoor>().enabled = true;
        }
        if (spawnTime <= 4 && spawnTime >= 3)
        {
            spawnedEnemies[2].GetComponent<enemyMover>().enabled = true;
            movedDoors[1].GetComponent<moveDoor>().enabled = true;
        }
        if (spawnTime <= 4 && spawnTime >= 3)
        {
            spawnedEnemies[3].GetComponent<enemyMover>().enabled = true;
            movedDoors[2].GetComponent<moveDoor>().enabled = true;
        }
        if (spawnTime <= 2 && spawnTime >= 1)
        {
            spawnedEnemies[4].GetComponent<enemyMover>().enabled = true;
            movedDoors[3].GetComponent<moveDoor>().enabled = true;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            spawner = true;
        }
    }
}

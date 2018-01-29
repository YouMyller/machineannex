using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour {

    string sceneNext;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("LevelSwitcher"))
        {
            if (SceneManager.GetActiveScene().name == "level_1")
            {
                sceneNext = "level_2";
                NextScene();
            }
            else if (SceneManager.GetActiveScene().name == "level_2")
            {
                sceneNext = "level_3";
                NextScene();
            }
        }
    }

    public void NextScene()
    {
        SceneManager.LoadScene(sceneNext);
    }
}

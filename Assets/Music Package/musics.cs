using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musics : MonoBehaviour {


    public AudioSource intro;
    public AudioSource loop;

    bool isPlaying;
	// Use this for initialization
	void Start ()
    {
        intro.Play();
        isPlaying = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (loop.isPlaying == false)
        {
            if (intro.isPlaying == false)
            {
                print("not play");
                isPlaying = false;
            }
        }

        while(isPlaying == false)
        {
            print("LOOOOP");
            isPlaying = true;
            loop.Play();
            loop.loop = true;
        }
	}
}

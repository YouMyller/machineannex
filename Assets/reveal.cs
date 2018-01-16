using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reveal : MonoBehaviour {

    public GameObject blinker;

    int looping = 0;

    bool done = true;

    bool atEnd = false;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(Wait());
	}


    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        transform.position -= new Vector3(0,20,0);
        yield return new WaitForSeconds(1);
        transform.position -= new Vector3(0, 20, 0);
        yield return new WaitForSeconds(0.2f);
        transform.position -= new Vector3(0, 20, 0);
        while (looping < 3)
        {
            yield return new WaitForSeconds(0.4f);
            blinker.transform.position += new Vector3(3, 0, 0);
            yield return new WaitForSeconds(0.4f);
            blinker.transform.position -= new Vector3(3,0,0);
            looping += 1;
        }
        blinker.transform.position -= new Vector3(0,60,0);
        transform.position -= new Vector3(0,20,0);
        yield return new WaitForSeconds(1);
        transform.position -= new Vector3(0, 20, 0);
        yield return new WaitForSeconds(0.2f);
        transform.position -= new Vector3(0, 20, 0);
        looping = 0;
        while (looping < 3)
        {
            yield return new WaitForSeconds(0.4f);
            blinker.transform.position += new Vector3(3, 0, 0);
            yield return new WaitForSeconds(0.4f);
            blinker.transform.position -= new Vector3(3, 0, 0);
            looping += 1;
        }
        blinker.transform.position -= new Vector3(-7, 50, 0);
        transform.position -= new Vector3(0, 20, 0);
        yield return new WaitForSeconds(1);
        transform.position -= new Vector3(0, 20, 0);
        atEnd = true;
        while (done)
        {
            yield return new WaitForSeconds(0.4f);
            blinker.transform.position += new Vector3(0, 20, 0);
            yield return new WaitForSeconds(0.4f);
            blinker.transform.position -= new Vector3(0, 20, 0);
        }



    }

    // Update is called once per frame
    void Update()
    {
        if (atEnd)
        { 
             if (Input.GetMouseButtonUp(0))
             {
                 done = false;
             }
        }
	}
}

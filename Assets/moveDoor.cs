using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveDoor : MonoBehaviour {

    public float moveTime = 1f;
    public float speed = .1f;

    private Rigidbody rb;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveTime -= Time.deltaTime;
        if (moveTime > 0)
        {
            //Debug.Log("Liikkuminen");
            transform.Translate(Vector2.up * speed);
        }
        if (moveTime < 0)
        {
            //Destroy(gameObject);
            speed = 0f;
            rb.isKinematic = true;
            //Debug.Log("höhö");

        }
    }
}

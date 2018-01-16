using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerDoorSecond : MonoBehaviour {

    public GameObject triggerObject;

    public float speed = .1f;
    public float moveTime = 1f;
    //public int moveup, movedown, moveright, moveleft;

    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!triggerObject.activeInHierarchy || !triggerObject)
        {
            Debug.Log("Vittu");
                moveTime -= Time.deltaTime;
                if (moveTime >= 0)
                {
                    transform.Translate(Vector2.up * speed);
                }
                if (moveTime <= 0)
                {
                    //Destroy(gameObject);
                    speed = 0f;
                    rb.isKinematic = true;
                }
        }
    }
}

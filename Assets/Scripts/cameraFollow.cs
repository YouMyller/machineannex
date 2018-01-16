using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {

    [SerializeField]
    private float xMax;
    [SerializeField]
    private float yMax;

    [SerializeField]
    private float xMin;
    [SerializeField]
    private float yMin;

    private Transform taaarget;

    public float smoothSpeed = 0.125f;

    public float waitTime = 1f;
    //public Vector2 offset;

    public CircleCollider2D target;
    public Vector2 focusAreaSize;

    public float verticalOffset;
    //public float horizontalOffset;

    FocusArea focusArea;

    private void Start()
    {
        focusArea = new FocusArea(target.bounds, focusAreaSize);
        taaarget = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        focusArea.Update(target.bounds);

        Vector2 focusPosition = focusArea.centre + Vector2.up * verticalOffset;

        //Vector2 focuspositionTwo = focusArea.centre + Vector2.right * horizontalOffset;

        transform.position = (Vector3)(focusPosition) + Vector3.forward * -10;  //+ focuspositionTwo

        /*waitTime -= Time.deltaTime;

        if (waitTime <= 0)
        {

            Vector2 desiredPosition = taaarget.position; //+ offset;

            Vector2 smoothedPosition = Vector2.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
        waitTime -= Time.deltaTime;
        */
        //Clamp the Camera. Hided as a comment for later use
        //(Might make it's own script for this one)
        //transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), transform.position.z);
    }

    struct FocusArea
    {
        public Vector2 centre;
        public Vector2 velocity;

        float left, right;
        float top, bottom;

        //Constructor
        public FocusArea(Bounds targetBounds, Vector2 size)
        {
            left = targetBounds.center.x - size.x / 2;
            right = targetBounds.center.x + size.x / 2;
            bottom = targetBounds.min.y;
            top = targetBounds.min.y + size.y;

            velocity = Vector2.zero;
            centre = new Vector2((left + right) / 2, (top + bottom) / 2);
        }

        public void Update(Bounds targetBounds)
        {
            //X
            float shiftX = 0;
            if (targetBounds.min.x < left)
            {
                shiftX = targetBounds.min.x - left;
            }
            else if (targetBounds.max.x > right)
            {
                shiftX = targetBounds.max.x - right;
            }

            left += shiftX;
            right += shiftX;

            //Y
            float shiftY = 0;
            if (targetBounds.min.y < bottom)
            {
                shiftY = targetBounds.min.y - bottom;
            }
            else if (targetBounds.max.y > top)
            {
                shiftY = targetBounds.max.y - top;
            }

            top += shiftY;
            bottom += shiftY;
            centre = new Vector2((left + right) / 2, (top + bottom) / 2);
            velocity = new Vector2(shiftX, shiftY);
        }
    }

        /*void OnTriggerExit2D(Collider2D col)
        {
            //Debug.Log("HURRAA");
            FixedUpdate();
            //waitTime -= Time.deltaTime;
            /*if (waitTime <= 0)
            {
                Vector2 desiredPosition = target.position; //+ offset;

                Vector2 smoothedPosition = Vector2.Lerp(transform.position, desiredPosition, smoothSpeed);
                transform.position = smoothedPosition;
            }

        }

        void OnTriggerEnter2D(Collider2D col)
        {
            //Debug.Log("Huzzah!");
            waitTime = 1f;
        }
    */
}

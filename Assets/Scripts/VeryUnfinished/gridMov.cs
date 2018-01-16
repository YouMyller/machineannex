using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridMov : MonoBehaviour {

    //Direction currentDir;
    Vector2 input;
    public bool isMoving = false;
    Vector3 startPos;
    Vector3 endPos;
    float t;

    public float walkSpeed = 10f;

    public bool dontMove = false;
    public bool kakka = false;

    public float rayCastMax = 25f;
    private float originPoint1 = 0.5f;

    public GameObject distObjectRight;
    public GameObject distObjectLeft;
    public GameObject distObjectUp;
    public GameObject distObjectDown;
    public GameObject wallObjectRight;
    public GameObject wallObjectLeft;
    public GameObject wallObjectUp;
    public GameObject wallObjectDown;


    // Update is called once per frame
    void FixedUpdate()
    {
        if (dontMove == false)
        {
            var distanceRight = Vector2.Distance(distObjectRight.transform.position, wallObjectRight.transform.position);


            //What if I had a bool that made all of this magic stop/happen when I want?
            if (!isMoving)
            {
                input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
                if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
                {
                    input.y = 0;
                }
                else
                {
                    input.x = 0;
                }
                if (input != Vector2.zero)
                {
                    StartCoroutine(Move(transform));
                }
            }
            if (distanceRight <= 5 && Input.GetKeyDown(KeyCode.RightArrow))
            {
                walkSpeed = 0;
                isMoving = false;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                walkSpeed = 10;
            }
        }
    }

    public IEnumerator Move(Transform entity)
    {
        //Or is this what I should use the bool on (as well)?
        isMoving = true;
        startPos = entity.position;
        t = 0;

        endPos = new Vector3(startPos.x + System.Math.Sign(input.x), startPos.y + System.Math.Sign(input.y), startPos.z); 

        while (t < 1f)
        {
            t += Time.deltaTime * walkSpeed;
            entity.position = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }

        isMoving = false;
        yield return 0;
    }

   /* void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("LeftOnly Rail")) //&& isMoving == false
        {
            dontMove = false;
            walkSpeed = 10f;
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
            {
                dontMove = false;
                walkSpeed = 10f;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                kakka = true;
                dontMove = true;
                walkSpeed = 0;
                //new Vector2(0, 0);
                //moveVelocity = new Vector2(0, 0);
                //myRigidBody.velocity = Vector2.zero;
            }
        }
    }




   /* private RaycastHit2D CheckRayCast(Vector2 direction)
    {
        float directionOriginPoint = originPoint1 * direction.x;  //> ? 1 : -1)

        Vector2 startingPosition = new Vector2(transform.position.x + directionOriginPoint, transform.position.y);

        Debug.DrawRay(startPos, direction, Color.red);

        return Physics2D.Raycast(startPos, direction, rayCastMax, 9);
    }

    private bool RaycastCheckUpdate()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector2 direction = new Vector2(1, 0);

            RaycastHit2D hit = CheckRayCast(direction);

            if (hit.collider)
            {
                Debug.Log("The raycast is hitting successfully. Now we can finally be a family again.");
            }

            return true;
        }
        else
        {
            return false;
        }
    }

    /*   enum Direction
       {
           North,
           East,
           South,
           West
       }
   */
}

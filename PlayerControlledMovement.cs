using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlledMovement : MonoBehaviour
{

    public float moveSpeed = 2.0f; //speed of objects in unity units per second
    public float constraints = 5;
    public bool wKeyDown = false;
    public bool sKeyDown = false;
    public bool dKeyDown = false;
    public bool aKeyDown = false;
    public float maxSpeed = 10.0f;
    public float minSpeed = 1.0f;
    public float speedIncrement = 1.0f;
    
    //private float elapsedTime = 0.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //timer function
        //elapsedTime += Time.deltaTime;
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
            //print(elapsedTime);
        //}

        //cause the ball to move when the arrow keys are pressed
        if (Input.GetKeyDown(KeyCode.W))
        { 
            wKeyDown = true;
            aKeyDown = false;
            sKeyDown = false;
            dKeyDown = false;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            sKeyDown = true;
            aKeyDown = false;
            dKeyDown = false;
            wKeyDown = false;
        }

        //left and right movement
        if (Input.GetKeyDown(KeyCode.A))
        {
            aKeyDown = true;
            dKeyDown = false;
            sKeyDown = false;
            wKeyDown = false;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            dKeyDown = true;
            aKeyDown = false;
            sKeyDown = false;
            wKeyDown = false;
        }

        //make it so the ball can only go in the 4 main directions
        if (wKeyDown == true)
        {
            transform.position = transform.position + (new Vector3(0, 0, 1)) * Time.deltaTime * moveSpeed;
        }
        else if (sKeyDown == true)
        {
            transform.position = transform.position + (new Vector3(0, 0, -1)) * Time.deltaTime * moveSpeed;
        }
        else if (dKeyDown == true)
        {
            transform.position = transform.position + (new Vector3(1, 0, 0)) * Time.deltaTime * moveSpeed;
        }
        else if (aKeyDown == true)
        {
            transform.position = transform.position + (new Vector3(-1, 0, 0)) * Time.deltaTime * moveSpeed;
        }


        //constrain to constrainDis units in x and z from the origin
        bool theCleanWay = true;
        if (theCleanWay)
        {
            Vector3 clampedPos = new Vector3(Mathf.Clamp(transform.position.x, -constraints,constraints), transform.position.y, Mathf.Clamp(transform.position.z,-constraints, constraints));
            transform.position = clampedPos;
        }
    }
}

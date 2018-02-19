using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 2.0f; //speed of objects in unity units per second
    public float maxSpeed = 5.0f;
    public float rotationAngle = 2f;
    public float thrust = 2f;
    public float jumpCount = 0;
    public float maxJumps = 1;

    public Transform playerCamera;
    public Transform playerModel;
    public Transform lazerSpawn;
    public GameObject lazer;
    Rigidbody rb;
    public Vector3 jumpForce = new Vector3(0, 250, 0);
    bool airborne = false;
    
    public Collider bounds;
    public Collider winBounds;
    public Vector3 startPosition = new Vector3(0, 1.5f, -20f);

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis("Mouse X");
        float yAxis = Input.GetAxis("Mouse Y");
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        
        //player movement
        if (Input.GetKey(KeyCode.W))
        {
            if (playerModel.transform.forward != playerCamera.transform.forward)
            {
                Vector3 cameraForward = playerCamera.transform.forward;
                cameraForward.y = 0;
                playerModel.transform.forward = cameraForward;
                playerModel.transform.position = playerModel.transform.position + (cameraForward) * Time.deltaTime * moveSpeed;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (playerModel.transform.forward != playerCamera.transform.forward)
            {
                Vector3 cameraForward = playerCamera.transform.forward;
                cameraForward.y = 0;
                playerModel.transform.forward = cameraForward;
                playerModel.transform.position = playerModel.transform.position + (-cameraForward) * Time.deltaTime * moveSpeed;
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (playerModel.transform.forward != playerCamera.transform.forward)
            {
                Vector3 cameraForward = playerCamera.transform.right;
                cameraForward.y = 0;
                playerModel.transform.forward = cameraForward;
                playerModel.transform.position = playerModel.transform.position + (cameraForward) * Time.deltaTime * moveSpeed;
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (playerModel.transform.forward != playerCamera.transform.forward)
            {
                Vector3 cameraForward = playerCamera.transform.right;
                cameraForward.y = 0;
                playerModel.transform.forward = -cameraForward;
                playerModel.transform.position = playerModel.transform.position - (cameraForward) * Time.deltaTime * moveSpeed;
            }
        }

        //jumping
        //if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        //{
        //    rb.AddForce(jumpForce);
        //    airborne = true;
        //    jumpCount += 1;
        //}
        //else if (jumpCount == maxJumps && playerModel.transform.position.y > 1.5) //reset jumps
        //{
        //    jumpCount = 0;
        //    airborne = false;
        //}

        //camera rotation
        float eulerAngleLimit = playerCamera.transform.eulerAngles.x;
        float minview = -15f;
        float maxview = 60f;

        if (eulerAngleLimit > 180)
        {
            eulerAngleLimit -= 360;
        }
        else if (eulerAngleLimit < -180)
        {
            eulerAngleLimit += 360;
        }

        float targetRotation = eulerAngleLimit + yAxis * -rotationAngle;

        if (xAxis > 0)
        {
            playerCamera.transform.Rotate(Vector3.up, rotationAngle, Space.World);
        }
        else if (xAxis < 0)
        {
            playerCamera.transform.Rotate(Vector3.up, -rotationAngle, Space.World);
        }

        if (targetRotation < maxview && targetRotation > minview)
        {
            playerCamera.transform.eulerAngles += new Vector3(yAxis * -rotationAngle, 0, 0);
        }

        //projectiles
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var projectileLazer = Instantiate(lazer, lazerSpawn.position, lazerSpawn.rotation);
            projectileLazer.GetComponent<Rigidbody>().velocity = projectileLazer.transform.forward * 30;
            Destroy(projectileLazer, 4f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        float exitPointX = playerModel.transform.position.x;
        float exitPointZ = playerModel.transform.position.z;
        float playerY = playerModel.position.y;
        Vector3 entryPointX = new Vector3(-exitPointX, playerY, exitPointZ);
        Vector3 entryPointZ = new Vector3(exitPointX, playerY, -exitPointZ);

        //if player exits from the pos x, start them at the -x, but at the same z
        if (exitPointX >= (bounds.transform.localScale.x) / 2)
        {
            playerModel.transform.position = entryPointX;
        }
        else if (exitPointX <= -(bounds.transform.localScale.x) / 2)
        {
            playerModel.transform.position = entryPointX;
        }
        //if player exits from pos z, starty them at -z but with same x
        if (exitPointZ >= (bounds.transform.localScale.z) / 2)
        {
            playerModel.transform.position = entryPointZ;
        }
        else if (exitPointZ <= -(bounds.transform.localScale.z) / 2)
        {
            playerModel.transform.position = entryPointZ;
        }
    }
}


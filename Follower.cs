using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public Transform playerObject;
    public Transform follower;
    public float followerMoveSpeed = 3.0f;

    public LayerMask raycastLayers;
    public LayerMask floorOnly;

    public float rayDistance = 5.0f;
    public float followDistance = 3f;

    private bool hitPlayer = false;
    private Vector3 rayCollisionNormal;
    private Vector3 hitLocThisFrame = Vector3.zero;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        hitPlayer = false;

        RaycastHit hitInfo;

        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, rayDistance, raycastLayers.value))
        {
            print("raycast hit " + hitInfo.transform.name + " at " + hitInfo.point);
            hitLocThisFrame = hitInfo.point;
            rayCollisionNormal = hitInfo.normal;

            if(Vector3.Distance(follower.position, playerObject.position) > followDistance)
            {
                follower.transform.LookAt(playerObject);
                follower.transform.position += follower.transform.forward * followerMoveSpeed * Time.deltaTime;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * rayDistance);
    }
}

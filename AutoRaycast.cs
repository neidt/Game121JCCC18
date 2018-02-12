using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRaycast : MonoBehaviour
{
    public LayerMask raycastLayers;
    public LayerMask floorOnly;

    public float rayDistance = 3.0f;

    //incase we hit
    private bool hitThisFrame = false;
    private Vector3 rayCollisionNormal;
    private Vector3 hitLocThisFrame = Vector3.zero;
    

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        hitThisFrame = false;

        RaycastHit hitInfo;
        
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, rayDistance, raycastLayers.value)) 
        {
            print("raycast hit" + hitInfo.transform.name + " at" + hitInfo.point);
            hitLocThisFrame = hitInfo.point;
            rayCollisionNormal = hitInfo.normal;
            hitThisFrame = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray intoScreen = Camera.main.ScreenPointToRay(Input.mousePosition); // hits whatever is under mouse at the time 
            if(Physics.Raycast(intoScreen, out hitInfo, 1000, floorOnly))
            {
                transform.position = hitInfo.point + new Vector3(0, 1, 0);
            }
        }
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * rayDistance);
    }
}

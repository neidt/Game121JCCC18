using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnHit : MonoBehaviour
{
    public GameObject lazer;
    public GameObject winObject;
    public GameObject playerObject;
    public Transform winObjectPosition;
    private hasWon winnerObject;

    private bool hasHit = false;

    // Use this for initialization
    void Start()
    {
        winnerObject = GameObject.FindGameObjectWithTag("GameController").GetComponent<hasWon>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hasHit) return;
        hasHit = true;

        Collider otherCollider = collision.collider;
        GameObject otherObject = collision.gameObject;
        Transform otherTransform = collision.transform;
        Rigidbody otherRigidbody = collision.rigidbody;

        Destroy(lazer);
        if (otherObject.tag != "Player")
        {
            Destroy(otherObject);
        }

        if (otherObject.tag == "Enemy")
        {
            winnerObject.objectsDestroyed++;
        }

        if(otherCollider.tag == "WinnerWinnerChickenDinner")
        {
            winObject.gameObject.SetActive(false);
            playerObject.GetComponent<Camera>().transform.position = -playerObject.GetComponent<Camera>().transform.position;
        }
    }


}
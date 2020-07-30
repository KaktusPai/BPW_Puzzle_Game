using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public GameObject ballPrefab;
    public bool justSpawned;

    void Start()
    {
        justSpawned = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0) && (justSpawned = true))
        {
            Rigidbody2D rb = ballPrefab.GetComponent<Rigidbody2D>(); 
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0f;
            rb.Sleep();
            Debug.Log("UP");
        }
        else if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("DOWN");
        }
    }
}

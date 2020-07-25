using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMechanic : MonoBehaviour
{

    public GameObject player;
    public Transform ball1;
    public Transform ball2;

    void Update()
    {

        if (Input.GetKey("e"))
        {
            player.transform.position =
            (ball1.transform.position + ball2.transform.position) / 2; 
        }
    }
}

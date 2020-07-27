using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMechanic : MonoBehaviour
{
    public GameObject player;
    public Transform ball1;
    public Transform ball2;

    public Transform firePoint;
    public GameObject ballPrefab;

    public float ballForce = 20f;

    void Update()
    {
        if (Input.GetKey("e"))
        {
            player.transform.position =
            (ball1.transform.position + ball2.transform.position) / 2; 
        }

        if(Input.GetButtonDown("Fire1"))
        {
            Throw();
        }
    }

    void Throw()
    {
        GameObject ball = Instantiate(ballPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * ballForce, ForceMode2D.Impulse);
    }


}

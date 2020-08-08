using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMechanic : MonoBehaviour
{
    public GameObject player;

    public Transform firePoint;
    public GameObject ballPrefab;

    public float ballForce = 13f;
    public int maxBalls = 3;
    GameObject currentBall;


    public float travelTime;
    private bool spawn = false;

    void Update()
    {
        if (Input.GetKey("e"))
        {
            Recall();
        }

        if (Input.GetMouseButtonDown(0) && GameObject.FindGameObjectsWithTag("ball").Length < maxBalls)
        {
            ThrowBall();
        }

        if (Input.GetMouseButtonUp(0) && currentBall || travelTime > 0.4 && currentBall)
        {
            StopBall();
        }

        if (currentBall && spawn == true)
        {
            travelTime += Time.deltaTime;
        }

        if (Input.GetKeyDown("space")) 
        {
            Teleport();
        }
    }

    void ThrowBall()
    {
        currentBall = (Instantiate(ballPrefab, firePoint.position, firePoint.rotation) as GameObject);
        Rigidbody2D rb = currentBall.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * ballForce, ForceMode2D.Impulse);
        spawn = true;
    }

    void StopBall()
    {
        Rigidbody2D rb = currentBall.GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
        travelTime = 0;
        spawn = false;
    }

    public void Recall()
    {
        Destroy(GameObject.FindWithTag("ball"));
    }

    void Teleport()
    {
        Vector3 meanVector = Vector3.zero;
        GameObject[] balls = GameObject.FindGameObjectsWithTag("ball");
        if (balls.Length > 1)
        {
            for (int i = 0; i < balls.Length; i++)
            {
                GameObject ball = balls[i];
                meanVector += ball.transform.position;
            }
            player.transform.position = meanVector / balls.Length;
        }
    }
}

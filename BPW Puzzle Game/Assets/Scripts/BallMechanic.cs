using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMechanic : MonoBehaviour
{
    public GameObject player;
    //public Transform ball1;
    //public Transform ball2;

    public Transform firePoint;
    public GameObject ballPrefab;

    public float ballForce = 13f;
    public int balls;
    public int maxBalls = 4;
    GameObject currentBall;

    
    public float travelTime;
    private bool spawn = false;


    void Update()
    {

        ////teleport to the middle of the balls
        //if (input.getkey("space"))
        //{
        //    player.transform.position =
        //    (ball1.transform.position + ball2.transform.position) / 2;
        //}
        //Recall all balls

        if (Input.GetKey("e"))
        {
            Recall();
        }

        if (Input.GetMouseButtonDown(0) && balls < maxBalls)
        {
            ThrowBall();
        }

        if (Input.GetMouseButtonUp(0) && currentBall || travelTime > 0.4)
        {
            StopBall();
        }

        if (currentBall && spawn == true)
        {
            travelTime += Time.deltaTime;
        }
    }

    void ThrowBall()        
    {
        List<GameObject> listOfBalls = new List<GameObject>();
        listOfBalls.Add(Instantiate(ballPrefab, firePoint.position, firePoint.rotation) as GameObject);
        Rigidbody2D rb = currentBall.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up* ballForce, ForceMode2D.Impulse);
        balls++;
        spawn = true;
    }

    void StopBall()
    {
        Rigidbody2D rb = currentBall.GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
        rb.Sleep();
        travelTime = 0;
        spawn = false;
    }

    void Recall()
    {
        Destroy(GameObject.FindWithTag("ball"));
        balls = 0;
    }
}
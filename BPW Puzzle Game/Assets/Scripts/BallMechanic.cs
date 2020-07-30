using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMechanic : MonoBehaviour
{
    public GameObject player;
    //public Transform ball1;
    //public Transform ball2;

    public Transform firePoint;
    public GameObject ballP1;
    public GameObject ballP2;
    public GameObject ballP3;

    public float ballForce = 13f;
    public int balls;
    public int maxBalls = 4;
    private bool spawn = true;
    private bool move = true;

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

        if (Input.GetMouseButton(0) && balls < maxBalls)
        {
            if (spawn == true)
            {
                GameObject ball1 = Instantiate(ballP1, firePoint.position, firePoint.rotation);
                Rigidbody2D rb = ballP1.GetComponent<Rigidbody2D>();
                if (move == true)
                {
                    rb.AddForce(firePoint.up * ballForce, ForceMode2D.Impulse);
                } else
                {
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = 0f;
                    rb.Sleep();
                }
                Debug.Log("moving");
                balls++;
                spawn = false;
            }
        } else
        {
            move = false;
        } 
    }

    void Recall()
    {
        Destroy(GameObject.FindWithTag("ball"));
        balls = 0;
    }
}
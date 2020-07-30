using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform firePoint;
    public GameObject ballPrefab;

    public float balls;
    public float maxBalls;
    public float ballForce = 13f;

    private bool spawn = true;

    void Update()
    {
        if (Input.GetMouseButton(0) && balls < maxBalls)
        {
            if (spawn == true)
            {
                GameObject ball = Instantiate(ballPrefab, firePoint.position, firePoint.rotation);
                Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint.up * ballForce, ForceMode2D.Impulse);
                balls++;
                spawn = false;
            }
        }
        else
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0f;
            rb.Sleep();
        }
    }
}

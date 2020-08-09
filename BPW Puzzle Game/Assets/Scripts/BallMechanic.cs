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
    private float travelTime;
    private bool spawn = false;
    GameObject currentBall;
    
    GameObject firstBall;
    public float fieldOfImpact;
    public LayerMask layerToHit;
    public Sprite explodeBall;
    public Sprite normalBall;
    public Sprite brokenWood;
    public GameObject explosionPrefab;


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

        if (Input.GetMouseButtonUp(0) && currentBall || travelTime > 0.5 && currentBall)
        {
            StopBall();
        }

        if (currentBall && spawn == true)
        {
            travelTime += Time.deltaTime;
        }

        if (Input.GetKeyDown("space"))
        {
            TeleportOrExplode();
        }

        BallUpdate();
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

    void Recall()
    {
        Destroy(GameObject.FindWithTag("ball"));
    }

    void TeleportOrExplode()
    {        
        Vector3 meanVector = Vector3.zero;
        float dist = 0f;
        GameObject[] balls = GameObject.FindGameObjectsWithTag("ball");
        if (balls.Length > 1)
        {
            for (int i = 0; i < balls.Length; i++)
            {
                GameObject ball = balls[i];
                meanVector += ball.transform.position;
                dist += Vector3.Distance(balls[0].transform.position, balls[1].transform.position);
                Debug.Log("dist: " + dist);
            }
            if (dist < 0.7 || dist == 0)
            {
                Explode();
                Debug.Log("Exploding!");
            } else
            {
                player.transform.position = meanVector / balls.Length;
            }
        }
    }  
    
    void BallUpdate() 
    {
        float dist = 0f;
        GameObject[] balls = GameObject.FindGameObjectsWithTag("ball");
        for (int i = 0; i < balls.Length; i++)
        {
            if (balls.Length > 1)
            {
                firstBall = balls[0];
                dist += Vector3.Distance(balls[0].transform.position, balls[1].transform.position);
            }
        }
        if (dist < 0.7 && dist > 0)
        {
            balls[0].GetComponent<SpriteRenderer>().sprite = explodeBall;
            balls[1].GetComponent<SpriteRenderer>().sprite = explodeBall;
        } else if (dist > 0.7)
        {
            balls[0].GetComponent<SpriteRenderer>().sprite = normalBall;
            balls[1].GetComponent<SpriteRenderer>().sprite = normalBall;
        }
    }

    void Explode()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(firstBall.transform.position, fieldOfImpact, layerToHit);
        foreach (Collider2D obj in objects)
        {
            Debug.Log(obj);
            BoxCollider2D woodCol = obj.GetComponent<BoxCollider2D>();
            woodCol.enabled = false;
            obj.GetComponent<SpriteRenderer>().sprite = brokenWood;
        }
        Instantiate(explosionPrefab, firstBall.transform.position, firstBall.transform.rotation);
        GameObject[] balls = GameObject.FindGameObjectsWithTag("ball");
        for (int i = 0; i < balls.Length; i++)
        {
            GameObject ball = balls[i];
            Destroy(ball);
        }
    }
}

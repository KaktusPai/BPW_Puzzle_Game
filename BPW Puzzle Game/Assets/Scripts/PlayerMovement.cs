using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Rigidbody2D throwrb;
    public Camera cam;
    public Transform player;
    public Transform respawnPoint;

    Vector2 movement;
    Vector2 mousePos;


    // Input
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    //Movement
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        throwrb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - throwrb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        throwrb.rotation = angle;
    }

    public void Retry()
    {
        player.transform.position = respawnPoint.transform.position;
        GameObject[] balls = GameObject.FindGameObjectsWithTag("ball");
        for (int i = 0; i < balls.Length; i++)
        {
            GameObject ball = balls[i];
            Destroy(ball);
        }
    }

}

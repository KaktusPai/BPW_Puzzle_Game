using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D collider)
    {
        if (gameObject.GetComponent<Rigidbody2D>().velocity == Vector2.zero)
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodScript : MonoBehaviour
{
    public Sprite broke;

    void OnCollisionEnter2D(collision2D Collision)
    {
        if (collision.gameObject.tag == "Ground_Smoke")
        {
            var hit = collision.contacts[0]; // let's get the first contact
                                             // find the rotation needed to make the smoke perpendicular to the hit surface
            var rot = Quaternion.FromToRotation(Vector3.up, hit.normal);
            Instantiate(explosionPrefab, hit.point, rot);
        }
    }

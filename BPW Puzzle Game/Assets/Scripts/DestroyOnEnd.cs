using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnEnd : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 0.2f);
    }
}

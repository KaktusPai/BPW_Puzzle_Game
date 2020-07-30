using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BigWin : MonoBehaviour
{ 
    void OnTriggerEnter2D(Collider2D Other)
    {
        SceneManager.LoadScene("Level2");
    }
}

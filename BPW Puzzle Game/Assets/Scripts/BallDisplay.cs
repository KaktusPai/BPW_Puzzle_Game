using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallDisplay : MonoBehaviour
{
    public Text ballText;   

    void Update()
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("ball");
        ballText.text = "Balls: " + balls.Length + "/3";
    }
}

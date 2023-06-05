using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooled : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D ball)
    {
        if (ball.gameObject.CompareTag("FireBall"))
        {
        gameObject.SetActive(false);
        }
    }
}

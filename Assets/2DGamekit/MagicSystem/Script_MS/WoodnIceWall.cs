using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

//Wall which can be destructed by Fire
public class WoodnIceWall : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D ball)
    {
        if (ball.gameObject.CompareTag("FireBall"))
        {
          Destroy(gameObject);
          Destroy(ball.gameObject);
        }
    }

}

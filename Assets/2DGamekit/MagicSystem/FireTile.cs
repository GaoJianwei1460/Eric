using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTile : MonoBehaviour
{
    public float bulletSpeed;
    Rigidbody2D rb;
    public GameObject impactEffect;
    //Vector2 direction = GetComponent<Renderer>().flipX ? Vector2.left : Vector2.right;
    //bool facingLeft = (direction == Vector2.left ? true : false);
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
      // if(!facingLeft){
      //  rb.velocity= transform.right*bulletSpeed;
     //  }
      // else if(facingLeft){
        rb.velocity= transform.right*bulletSpeed;
      // }
    }

    void Update()
    {
        Instantiate(impactEffect,transform.position,Quaternion.identity);
        Destroy(gameObject);    
    }

    void OnTriggerEnter2D(Collider2D wall)
    {
        if (wall.gameObject.CompareTag("Tilemap"))
        {
          Destroy(gameObject);
        }
    }
}

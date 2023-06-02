using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbLadder : MonoBehaviour
{
public float climbSpeed;

    public bool isClimbing;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Ladder") && Input.GetKey(KeyCode.W))
        {
            isClimbing = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isClimbing = false;
        }
    }

    void FixedUpdate()
    {
        if (isClimbing)
        {
            float verticalInput = Input.GetAxisRaw("Vertical");
            float climbVelocity = verticalInput * climbSpeed;

            Rigidbody2D playerRigidbody = GetComponent<Rigidbody2D>();
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, climbVelocity);
            playerRigidbody.gravityScale = 0f;
        }
        else
        {
            Rigidbody2D playerRigidbody = GetComponent<Rigidbody2D>();
            playerRigidbody.gravityScale = 1f;
        }
    }
}

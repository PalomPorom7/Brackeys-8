using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovementController : MonoBehaviour
{
    public Rigidbody2D  body,
                        currentPlatform;

    public float    movementForce,
                    maxVelocity;

    private float   currentVelocity,
                    xInput;
    
    public bool     isStandingOnPlatform;

    public void Move(Vector2 direction)
    {
        xInput = direction.x;
    }

    private void FixedUpdate()
    {
        body.AddForce(new Vector2(xInput * movementForce * Time.fixedDeltaTime, body.velocity.y));

        currentVelocity = body.velocity.x;

        if(currentVelocity < -maxVelocity)
            currentVelocity = -maxVelocity;
        else if(currentVelocity > maxVelocity)
            currentVelocity = maxVelocity;

        body.velocity = new Vector2(currentVelocity, body.velocity.y);
        if (isStandingOnPlatform) body.velocity += currentPlatform.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Platform")
        {
            isStandingOnPlatform = true;
            currentPlatform = collision.rigidbody;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Platform")
        {
            isStandingOnPlatform = false;
            currentPlatform = null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovementController : MonoBehaviour
{
    public Rigidbody2D body;
    public float    movementForce,
                    maxVelocity;

    private float   currentVelocity,
                    xInput;

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
    }
}

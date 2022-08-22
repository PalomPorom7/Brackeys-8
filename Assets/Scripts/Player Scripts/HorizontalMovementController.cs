using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovementController : MonoBehaviour
{
    public Rigidbody2D body;
    public float movementSpeed;

    private Vector2 input;

    public void Move(Vector2 direction)
    {
        input = direction;
    }
    private void FixedUpdate()
    {
        body.velocity = new Vector2(input.x * movementSpeed * Time.fixedDeltaTime, body.velocity.y);
    }
}

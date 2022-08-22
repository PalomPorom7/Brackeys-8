using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public Rigidbody2D body;

    public bool     startJump;
    public float    startJumpForce,
                    holdJumpForce,
                    maxholdDuration;

    private float   jumpHoldDuration;

    private void Start()
    {
        if(body == null)
            body = GetComponent<Rigidbody2D>();
    }
    public void StartJump()
    {
        startJump = true;
        jumpHoldDuration = 0;
    }
    public void HoldJump(float jumpHoldDuration)
    {
        this.jumpHoldDuration = jumpHoldDuration;
    }
    public void StopJump()
    {
        jumpHoldDuration = 0;
    }
    private void FixedUpdate()
    {
        if(startJump)
        {
            body.AddForce(Vector2.up * startJumpForce);
            startJump = false;
        }
        if(jumpHoldDuration != 0)
        {
            if(jumpHoldDuration > maxholdDuration)
                return;

            body.AddForce(Vector2.up * holdJumpForce);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public Rigidbody2D body;
    public AudioClip jumpSound;

    public bool     startJump,
                    canJump = true;
    public float    startJumpForce,
                    holdJumpForce,
                    maxholdDuration,
                    maxVelocity;

    private float   jumpHoldDuration,
                    currentVelocity;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if(body == null)
            body = GetComponent<Rigidbody2D>();
    }

    public void StartJump()
    {
        if (!canJump) return;
        startJump = true;
        jumpHoldDuration = 0;
        audioSource.PlayOneShot(jumpSound);
    }

    public void HoldJump(float jumpHoldDuration)
    {
        this.jumpHoldDuration = jumpHoldDuration;
    }
    public void StopJump()
    {
        canJump = false;
        jumpHoldDuration = 0;
    }
    public void StopJumpBySwap()
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
        if(jumpHoldDuration != 0 && canJump)
        {
            if(jumpHoldDuration > maxholdDuration)
                return;

            body.AddForce(Vector2.up * holdJumpForce);
        }
        currentVelocity = body.velocity.y;
        
        if(currentVelocity < -maxVelocity)
            currentVelocity = -maxVelocity;
        else if(currentVelocity > maxVelocity)
            currentVelocity = maxVelocity;

        body.velocity = new Vector2(body.velocity.x, currentVelocity);
    }
}

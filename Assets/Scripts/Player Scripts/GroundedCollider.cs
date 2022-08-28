using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundedCollider : MonoBehaviour
{
    public bool isGrounded = false;
    public UnityEvent OnJumpEvent;
    public UnityEvent OnLandEvent;

    private void OnTriggerStay2D(Collider2D collision)
    {
        isGrounded = true;
        OnLandEvent.Invoke();
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
        OnJumpEvent.Invoke();
    }
}

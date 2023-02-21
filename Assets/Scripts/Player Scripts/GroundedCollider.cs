using UnityEngine;
using UnityEngine.Events;

public class GroundedCollider : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    public bool isGrounded = false;
    public bool isSwimming = false;
    public UnityEvent OnJumpEvent;
    public UnityEvent OnLandEvent;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            if(GetComponentInParent<Rigidbody2D>().velocity.y == 0)
            {
                transform.parent.SetParent(collision.transform, true);
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
        OnLandEvent.Invoke();
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            transform.parent.SetParent(null);
        }
        isGrounded = false;
        OnJumpEvent.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Water")
            isSwimming = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Water")
            isSwimming = false;
    }
}

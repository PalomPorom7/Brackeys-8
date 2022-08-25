using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public HorizontalMovementController horizontalMovementController;
    public JumpController               jumpController;
    public SwitchController             switchController;
    public StateController              stateController;
    public GroundedCollider             groundCollision;

    private void Start()
    {
        if(horizontalMovementController == null)
            horizontalMovementController = GetComponent<HorizontalMovementController>();

        if(jumpController == null)
            jumpController = GetComponent<JumpController>();

        if(switchController == null)
            switchController = GetComponent<SwitchController>();

        if(stateController == null)
            stateController = GetComponent<StateController>();
        
        groundCollision.OnJumpEvent.AddListener(() => {
            // slight animmation here
        });

        groundCollision.OnLandEvent.AddListener(() => {
            jumpController.canJump = true;
            // Also maybe add some dust particles and animation
        });
    }
    public void ChangeState()
    {
        stateController.ChangeState();
    }

    public void SetActive(bool active)
    {
        switchController.ToggleIndicator(active);

        if(active)
            return;

        Move(Vector2.zero);
        jumpController.StopJumpBySwap();
    }

    public void Move(Vector2 direction)
    {
        horizontalMovementController.Move(direction);
    }

    public void JumpPressed()
    {
        if(groundCollision.isGrounded)
            jumpController.StartJump();
    }

    public void JumpHeld(float holdDuration)
    {
        jumpController.HoldJump(holdDuration);
    }

    public void JumpReleased()
    {
        jumpController.StopJump();
    }
}

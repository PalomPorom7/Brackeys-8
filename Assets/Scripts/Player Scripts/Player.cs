using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public HorizontalMovementController horizontalMovementController;
    public JumpController               jumpController;
    public SwitchController             switchController;
    public StateController              stateController;

    public bool isGrounded;

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
    }
    public void ChangeState()
    {
        stateController.ChangeState();
    }
    public void SetActive(bool active)
    {
        switchController.ToggleIndicator(active);
    }
    public void Move(Vector2 direction)
    {
        horizontalMovementController.Move(direction);
    }
    public void JumpPressed()
    {
//        if(isGrounded)
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public Player player1, player2;

    public Player currentPlayer;

    public float    horizontalInput,
                    jumpHoldDuration;

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if(horizontalInput != 0)
        {
            currentPlayer.Move(new Vector2(horizontalInput, 0));
        }
        if(Input.GetButtonDown("Switch"))
        {
            if(currentPlayer == player1)
            {
                player1.SetActive(false);
                currentPlayer = player2;
                player2.SetActive(true);
            }
            else if(currentPlayer = player2)
            {
                player2.SetActive(false);
                currentPlayer = player1;
                player1.SetActive(true);
            }
        }
        if(Input.GetButtonDown("Jump"))
        {
            jumpHoldDuration = 0;
            currentPlayer.JumpPressed();
        }
        if(Input.GetButton("Jump"))
        {
            currentPlayer.JumpHeld(jumpHoldDuration += Time.deltaTime);
        }
        if(Input.GetButtonUp("Jump"))
        {
            currentPlayer.JumpReleased();
        }
        if(Input.GetButtonDown("ChangeState"))
        {
            player1.ChangeState();
            player2.ChangeState();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public Player p1, p2;

    public Player current;

    private void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            p1.ChangeState();
            p2.ChangeState();
        }
    }
}

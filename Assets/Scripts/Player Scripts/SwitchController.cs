using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public SpriteRenderer indicator;
    public void ToggleIndicator(bool active)
    {
        indicator.enabled = active;
    }
}

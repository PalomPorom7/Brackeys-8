using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonObject : MonoBehaviour
{
    public iControlledObject controlledObject;
    public Sprite defaultSprite;
    public Sprite pressedSprite;
    public Color defaultColour = Color.white;
    public Color pressedColour = Color.white;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        controlledObject.Activate();
        spriteRenderer.sprite = pressedSprite;
        spriteRenderer.color = pressedColour;
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        controlledObject.Deactivate();
        spriteRenderer.sprite = defaultSprite;
        spriteRenderer.color = defaultColour;
    }
}

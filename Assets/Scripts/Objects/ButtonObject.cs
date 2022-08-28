using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonObject : MonoBehaviour
{
    public GameObject       controlledObject;
    public Sprite           defaultSprite;
    public Sprite           pressedSprite;
    public Color            defaultColour = Color.white,
                            pressedColour = Color.white;

    private SpriteRenderer      spriteRenderer;
    private iControlledObject   controller;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        controller = controlledObject.GetComponent<iControlledObject>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spriteRenderer.sprite = pressedSprite;
        spriteRenderer.color = pressedColour;
        GetComponent<AudioSource>().Play();
        controller.Activate();
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRenderer.sprite = defaultSprite;
        spriteRenderer.color = defaultColour;
        GetComponent<AudioSource>().Play();
        controller.Deactivate();
    }
}

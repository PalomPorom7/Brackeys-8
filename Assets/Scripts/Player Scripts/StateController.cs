using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    horizontal,
    vertical
}
public class StateController : MonoBehaviour
{
    public SizeController   size;
    public SpriteRenderer   indicator,
                            body,
                            eyes,
                            mouth;

    public Sprite[]         eyesSprites,
                            mouthSprites;
    public BoxCollider2D    bodyCollider,
                            groundColider;
    public PlayerState      state;
    public float            changeStateSpeed;
    public EasingType       changeStateAnimation;

    public float            blinkDuration;
    private float           blinkDelay;

    private Vector2 startIndicatorPosition,
                    currentIndicatorPosition,
                    endIndicatorPosition,
                    startSize,
                    currentSize,
                    endSize,
                    startColliderOffset,
                    currentColliderOffset,
                    endColliderOffset,
                    startFacePosition,
                    currentFacePosition,
                    endFacePosition,
                    startGroundColliderSize,
                    endGroundColliderSize,
                    currentGroundColliderSize;
    private float   changeStateTime,
                    easedTime;

    private bool isChangingState = false;
    private void Start()
    {
        currentIndicatorPosition    = indicator.transform.localPosition;
        currentSize                 = body.size;
        currentColliderOffset       = bodyCollider.offset;
        currentFacePosition         = eyes.transform.localPosition;
        currentGroundColliderSize   = groundColider.size;

        StartCoroutine("Blink");
    }
    public bool ChangeState()
    {
        if(isChangingState)
            return false;

        //check if there's room first?

        changeStateTime         = 0;
        startIndicatorPosition  = currentIndicatorPosition;
        startSize               = currentSize;
        startColliderOffset     = currentColliderOffset;
        startFacePosition       = currentFacePosition;
        startGroundColliderSize = currentGroundColliderSize;

        if(state == PlayerState.horizontal)
        {
            state                   = PlayerState.vertical;
            endIndicatorPosition    = size.verticalIndicatorPosition;
            endSize                 = size.verticalBodySize;
            endColliderOffset       = size.verticalColliderOffset;
            endFacePosition         = size.verticalFacePosition;
            endGroundColliderSize   = size.verticalGroundColliderSize;
            
        }
        else if(state == PlayerState.vertical)
        {
            state                   = PlayerState.horizontal;
            endIndicatorPosition    = size.horizontalIndicatorPosition;
            endSize                 = size.horizontalBodySize;
            endColliderOffset       = size.horizontalColliderOffset;
            endFacePosition         = size.horizontalFacePosition;
            endGroundColliderSize   = size.horizontalGroundColliderSize;
        }
        StartCoroutine("AnimateStateChange");
        return true;
    }

    private void ChangeLayer(int layer)
    {
        gameObject.layer = layer;
        bodyCollider.gameObject.layer = layer;
        groundColider.gameObject.layer = layer;
    }
    public void Happy(bool hasInput)
    {
        if(isChangingState)
            return;
        
        if(hasInput)
            mouth.sprite = mouthSprites[1];
        else
            mouth.sprite = mouthSprites[0];
    }
    private IEnumerator Blink()
    {
        while(true)
        {
            print("blink");
            eyes.sprite = eyesSprites[1];

            yield return new WaitForSeconds(blinkDuration);

            if(!isChangingState)
                eyes.sprite = eyesSprites[0];
            
            blinkDelay = Random.Range(5, 10);
            yield return new WaitForSeconds(blinkDelay);
        }
    }
    private IEnumerator AnimateStateChange()
    {
        isChangingState = true;

        eyes.sprite = eyesSprites[1];
        mouth.sprite = mouthSprites[2];

        while(changeStateTime < 1)
        {
            changeStateTime += Time.deltaTime * changeStateSpeed;
            easedTime        = Easing.Ease(changeStateTime, changeStateAnimation);

            currentIndicatorPosition    = Vector2.LerpUnclamped(startIndicatorPosition, endIndicatorPosition, easedTime);
            currentSize                 = Vector2.LerpUnclamped(startSize, endSize, easedTime);
            currentColliderOffset       = Vector2.LerpUnclamped(startColliderOffset, endColliderOffset, easedTime);
            currentFacePosition         = Vector2.LerpUnclamped(startFacePosition, endFacePosition, easedTime);
            currentGroundColliderSize   = Vector2.LerpUnclamped(startGroundColliderSize, endGroundColliderSize, easedTime);

            indicator.transform.localPosition   = currentIndicatorPosition;
            body.size                           = currentSize;
            bodyCollider.size                   = currentSize;
            bodyCollider.offset                 = currentColliderOffset;
            eyes.transform.localPosition        = currentFacePosition;
            mouth.transform.localPosition       = currentFacePosition;
            groundColider.size                  = currentGroundColliderSize;

            yield return null;
        }
        ChangeLayer(state == PlayerState.horizontal ? 6 : 7);

        eyes.sprite = eyesSprites[0];
        mouth.sprite = mouthSprites[0];

        isChangingState = false;
    }
}

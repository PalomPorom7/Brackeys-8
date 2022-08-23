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
    public BoxCollider2D    bodyCollider;
    public PlayerState      state;
    public float            changeStateSpeed;
    public EasingType       changeStateAnimation;

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
                    endFacePosition;
    private float   changeStateTime,
                    easedTime;

    private bool isChangingState = false;
    private void Start()
    {
        currentIndicatorPosition    = indicator.transform.localPosition;
        currentSize                 = body.size;
        currentColliderOffset       = bodyCollider.offset;
        currentFacePosition         = eyes.transform.localPosition;
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

        if(state == PlayerState.horizontal)
        {
            state                   = PlayerState.vertical;
            endIndicatorPosition    = size.verticalIndicatorPosition;
            endSize                 = size.verticalBodySize;
            endColliderOffset       = size.verticalColliderOffset;
            endFacePosition         = size.verticalFacePosition;
        }
        else if(state == PlayerState.vertical)
        {
            state                   = PlayerState.horizontal;
            endIndicatorPosition    = size.horizontalIndicatorPosition;
            endSize                 = size.horizontalBodySize;
            endColliderOffset       = size.horizontalColliderOffset;
            endFacePosition         = size.horizontalFacePosition;
        }
        StartCoroutine("AnimateStateChange");
        return true;
    }
    private IEnumerator AnimateStateChange()
    {
        isChangingState = true;

        while(changeStateTime < 1)
        {
            changeStateTime += Time.deltaTime * changeStateSpeed;
            easedTime        = Easing.Ease(changeStateTime, changeStateAnimation);

            currentIndicatorPosition    = Vector2.LerpUnclamped(startIndicatorPosition, endIndicatorPosition, easedTime);
            currentSize                 = Vector2.LerpUnclamped(startSize, endSize, easedTime);
            currentColliderOffset       = Vector2.LerpUnclamped(startColliderOffset, endColliderOffset, easedTime);
            currentFacePosition         = Vector2.LerpUnclamped(startFacePosition, endFacePosition, easedTime);

            indicator.transform.localPosition   = currentIndicatorPosition;
            body.size                           = currentSize;
            bodyCollider.size                   = currentSize;
            bodyCollider.offset                 = currentColliderOffset;
            eyes.transform.localPosition        = currentFacePosition;
            mouth.transform.localPosition       = currentFacePosition;

            yield return null;
        }
        isChangingState = false;
    }
}
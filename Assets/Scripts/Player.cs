using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    horizontal,
    vertical
}
public class Player : MonoBehaviour
{
    public State state;
    public float changeStateSpeed;

    public Vector2  horizontalScale,
                    verticalScale;
    private Vector2 startScale,
                    currentScale,
                    endScale;

    private float changeStateTime;
    public bool ChangeState()
    {

        //check if there's room first

        changeStateTime = 0;
        startScale = transform.localScale;

        if(state == State.horizontal)
        {
            endScale = verticalScale;
            state = State.vertical;
        }
        else if(state == State.vertical)
        {
            endScale = horizontalScale;
            state = State.horizontal;
        }
        StartCoroutine("AnimateStateChange");
        return true;
    }
    private IEnumerator AnimateStateChange()
    {
        while(changeStateTime < 1)
        {
            changeStateTime += Time.deltaTime * changeStateSpeed;
            currentScale = Vector2.LerpUnclamped(startScale, endScale, changeStateTime);
            transform.localScale = currentScale;
            yield return null;
        }
    }
}

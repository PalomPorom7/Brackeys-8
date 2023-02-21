using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlatformControlledObject : MonoBehaviour, iControlledObject
{
    private Rigidbody2D body;

    [SerializeField]
    public Vector3      startPosition,
                        targetPosition,
                        resetPosition;

    [SerializeField]
    public float        speed = 1;

    [SerializeField]
    public bool         willPace;

    private bool        isActivated = false,
                        willReturn = false;
    private float       currentTime = 0;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (willPace)
            UpdatePacing();
        else
            UpdateNotPacing();
    }
    
    // The behaviour for pacing will that it will oscillate between the two positions if it is active.
    // If the platform is deactived mid move, it will stop in place.
    void UpdatePacing()
    {
        if (!isActivated)
            return;

        currentTime += Time.deltaTime;

        if (willReturn)
        {
            if (transform.position != startPosition)
                LerpHelper(targetPosition, startPosition);
            else
            {
                willReturn = false;
                currentTime = 0;
            }
        }
        else
        {
            if (transform.position != targetPosition)
                LerpHelper(startPosition, targetPosition);
            else
            {
                willReturn = true;
                currentTime = 0;
            }
        }
    }

    // If the switch is on, it will move towards the targetPostion
    // If the switch is off, it will move towards the start position
    private void UpdateNotPacing()
    {
        currentTime += Time.deltaTime;

        if (isActivated)
        {
            if (transform.position != targetPosition)
                LerpHelper(resetPosition, targetPosition);
        }
        else
        {
            if (transform.position != startPosition)
                LerpHelper(resetPosition, startPosition);
        }
    }

    private void LerpHelper(Vector3 start, Vector3 end)
    {
        transform.position = (Vector2.Lerp(start, end, (currentTime/Vector2.Distance(start, end)) * speed));
    }

    public void Activate()
    {
        isActivated = true;
        resetPosition = transform.position;

        if (!willPace)
            currentTime = 0;
    }

    public void Deactivate()
    {
        isActivated = false;
        resetPosition = transform.position;

        if (!willPace)
            currentTime = 0;
    }

}

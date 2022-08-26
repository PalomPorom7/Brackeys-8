using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanSpin : MonoBehaviour, iControlledObject
{
    public Transform spriteTransform;
    public ParticleSystem windParticles;
    public float fanSpeed = 50f;
    public float timeToMaxSpeed = 2f;
    public bool isSpinning = true;

    private Vector3 rotation;

    private float currentSpeed = 0;
    private float currentTime = 0;

    void Start()
    {
        rotation = spriteTransform.localEulerAngles;    
        if (isSpinning) windParticles.Play();
        else windParticles.Stop();
    }

    // Update is called once per frame
    void Update()
    {

        if (isSpinning)
        {
            if (currentTime <= timeToMaxSpeed) currentTime += Time.deltaTime;
            else currentTime = timeToMaxSpeed;

            if (!windParticles.isPlaying) windParticles.Play();
        }
        else
        {
            if (currentTime >= 0) currentTime -= Time.deltaTime;
            else currentTime = 0;

            if (windParticles.isPlaying) windParticles.Stop();
        }
        
        currentSpeed = Mathf.Lerp(0, fanSpeed, Easing.SineIn(currentTime / timeToMaxSpeed));
    }

    private void FixedUpdate()
    {
        rotation.z += currentSpeed;
        if (rotation.z >= 360f) rotation.z -= 360f;
        spriteTransform.localEulerAngles = rotation;
    }
    
    public void Activate()
    {
        isSpinning = true;
    }

    public void Deactivate()
    {
        isSpinning = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSplash : MonoBehaviour
{
    public AudioSource source;
    public AudioClip splash;

    private bool canPlay = true;
    private float timeSinceLastSplash;
    public float minimumTimeBetweenSplashes;

    private void OnTriggerEnter2D(Collider2D c)
    {
        if(!canPlay)
            return;
        source.PlayOneShot(splash);
        StartCoroutine("DelaySplash");
    }
    private void OnTriggerExit2D(Collider2D c)
    {
        if(!canPlay)
            return;
        source.PlayOneShot(splash);
        StartCoroutine("DelaySplash");
    }
    private IEnumerator DelaySplash()
    {
        canPlay = false;
        timeSinceLastSplash = 0;

        while(timeSinceLastSplash < minimumTimeBetweenSplashes)
        {
            timeSinceLastSplash += Time.deltaTime;
            yield return null;
        }
        canPlay = true;
    }
}

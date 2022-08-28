using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMask : MonoBehaviour
{
    bool isShowing = false;
    Vector3 startScale = Vector3.zero;
    Vector3 endScale = new Vector3(100, 100, 100);
    float currentTime = 2;
    float totalTime = 2;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = startScale;
        StartCoroutine(ShowAfterDelay(1));
    }

    // Update is called once per frame
    void Update()
    {
        if (isShowing)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= totalTime) currentTime = totalTime;
            transform.localScale = Vector3.Lerp(startScale, endScale, Easing.QuadOut(currentTime/totalTime));
        }
        else
        {
            currentTime += Time.deltaTime;
            if (currentTime >= totalTime) currentTime = totalTime;
            transform.localScale = Vector3.Lerp(endScale, startScale, Easing.QuadOut(currentTime/totalTime));
        }
    }

    public void Show()
    {
        isShowing = true;
        currentTime = 0;
    }

    public void Hide()
    {
        isShowing = false;
        currentTime = 0;
    }

    IEnumerator ShowAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Show();
    }
}

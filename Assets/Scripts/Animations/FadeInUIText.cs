using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInUIText : MonoBehaviour
{
    Color start = Color.white;
    Color end = Color.white;
    float currentTime = 0;
    Text text;
    bool isHiding = false;

    private void Start()
    {
        text = GetComponent<Text>();
        start.a = 0;
        text.color = start;
    }
    private void Update()
    {
        if (!isHiding)
        {
            if (currentTime >= 4)
                return;

            currentTime += Time.deltaTime;

            if (currentTime >= 2)
            {
                if (currentTime > 4)
                    currentTime = 4;

                text.color = Color.Lerp(start, end, (currentTime - 2)/2);
            }
        }
        else
        {
            if (currentTime >= 0.5f)
                return;

            currentTime += Time.deltaTime;

            if (currentTime > 0.5f)
                currentTime = 0.5f;

            text.color = Color.Lerp(end, start, currentTime/0.5f);
        }
    }

    public void Hide()
    {
        isHiding = true;
        currentTime = 0;
    }
}

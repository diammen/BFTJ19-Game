using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeTransition : MonoBehaviour
{
    CanvasGroup canvas;
    public float fadeDelay;

    private void Start()
    {
        canvas = GetComponent<CanvasGroup>();
    }

    public void DoFade()
    {
        StartCoroutine(Fade(fadeDelay));
    }

    IEnumerator Fade(float _fadeDelay)
    {
        for (float i = 0; i < 1; i += 0.1f)
        {
            canvas.alpha = i;
            yield return new WaitForSeconds(fadeDelay);
        }
    }
}

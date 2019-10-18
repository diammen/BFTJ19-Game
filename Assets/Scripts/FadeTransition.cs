using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FadeTransition : MonoBehaviour
{
    public UnityEvent onFadeCompleted;

    GameManager gm;
    CanvasGroup canvas;
    public float duration;
    public bool isFading;

    float elapsed;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        canvas = GetComponent<CanvasGroup>();

        gm.fade = this;

        DoFade(false);
    }

    public void DoFade(bool isFadingOut)
    {
        isFading = true;
        StartCoroutine(Fade(duration, isFadingOut));
    }

    IEnumerator Fade(float _duration, bool fadingOut)
    {
        float start = fadingOut ? 0 : 1;
        float end = fadingOut ? 1 : 0;

        elapsed = 0;

        while ((elapsed / duration) <= 1.1)
        {
            canvas.alpha = Mathf.Lerp(start, end, elapsed / _duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        isFading = false;
        onFadeCompleted.Invoke();
    }
}

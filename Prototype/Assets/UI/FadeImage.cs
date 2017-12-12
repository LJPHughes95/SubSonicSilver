using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeImage : MonoBehaviour {

    public Image image;
    public float fadeTime;
    public float displayTime;

    private void Awake()
    {
        StartCoroutine(TimeWait());
    }

    public IEnumerator TimeWait()
    {
        GameManager.PauseGame();

        yield return new WaitForSecondsRealtime(displayTime);

        image.canvasRenderer.SetAlpha(1.0f);
        image.CrossFadeAlpha(0.0f, fadeTime, false);
        GameManager.UnPauseGame();
    }

    public float CumulativeTime()
    {
        return fadeTime + displayTime;
    }
}

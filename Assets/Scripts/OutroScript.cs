using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OutroScript : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration;
    public bool stopTime;
    public UnityEngine.Events.UnityEvent additionalEventsEnd;
    Color col;

    private void Start()
    {
        col = fadeImage.color;
        col.a = 0;
        fadeImage.color = col;
    }

    public void FadeOut(string sceneToLoad)
    {
        additionalEventsEnd.AddListener(() => { SceneManager.LoadScene(sceneToLoad); });

        if (stopTime)
            Time.timeScale = 0;

        StartCoroutine(fadeEffect());
    }

    IEnumerator fadeEffect()
    {
        col = fadeImage.color;
        float count = 0;

        do
        {
            yield return null;
            count += Time.unscaledDeltaTime;
            col.a = Mathf.InverseLerp(0, fadeDuration, count);
            fadeImage.color = col;
        }
        while (count < fadeDuration);

        yield return null;

        additionalEventsEnd.Invoke();
    }
}

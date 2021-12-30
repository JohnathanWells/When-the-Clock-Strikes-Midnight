using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class IntroScript : MonoBehaviour
{
    public VerticalLayoutGroup displayArea;
    public TextMeshProUGUI textPrefab;
    public string[] paragraphs;
    public float spaceBetweenParagraphs;
    public PauseMenu pauseMenu;
    public float fadeInTime;
    public float fadeOutTime;
    public float timeBefore;
    public float timeBetween;
    public float timeAfter;
    public float startupTime;

    TextMeshProUGUI[] textDisplays;
    public UnityEngine.Events.UnityEvent onStart;
    public UnityEngine.Events.UnityEvent onEnd;

    public void Start()
    {
        onStart.Invoke();
        StartCoroutine(intro());
    }

    IEnumerator intro()
    {
        MysteryManager.timeProgressStopped = true;
        Debug.Log("Intro started");

        pauseMenu.SneakyPause(true);
        pauseMenu.SetEyelids(false);
        //pauseMenu.SetMenuShow(true);
        pauseMenu.SetMenuShow(false);
        //pauseMenu.SetMenuShowSneaky(false);
        pauseMenu.lockPause = true;

        displayArea.spacing = spaceBetweenParagraphs;
        textDisplays = new TextMeshProUGUI[paragraphs.Length];
        float count = 0;
        yield return new WaitForSecondsRealtime(timeBefore);

        for (int i = 0; i < paragraphs.Length; i++)
        {
            textDisplays[i] = Instantiate(textPrefab, displayArea.transform);

            textDisplays[i].text = paragraphs[i];

            displayArea.CalculateLayoutInputVertical();

            Color col = textDisplays[i].color;
            col.a = 0;

            textDisplays[i].color = col;
        }

        for (int n = 0; n < paragraphs.Length; n++)
        {
            count = 0;
            Color col = textDisplays[n].color;

            while (count < fadeInTime)
            {
                col.a = Mathf.InverseLerp(0, fadeInTime, count);

                textDisplays[n].color = col;
                count += Time.unscaledDeltaTime;
                yield return null;
            }
            col.a = 1;
            textDisplays[n].color = col;

            yield return new WaitForSecondsRealtime(timeBetween);
        }

        yield return new WaitForSecondsRealtime(timeAfter);

        count = fadeOutTime;

        while (count > 0)
        {
            for (int n = 0; n < textDisplays.Length; n++)
            {
                Color col = textDisplays[n].color;
                col.a = Mathf.InverseLerp(0, fadeOutTime, count);
                textDisplays[n].color = col;
            }

            count -= Time.unscaledDeltaTime;

            yield return null;
        }

        yield return new WaitForSecondsRealtime(startupTime);

        MysteryManager.timeProgressStopped = false;
        pauseMenu.lockPause = false;
        pauseMenu.SetPause(false);

        onEnd.Invoke();
    }
}

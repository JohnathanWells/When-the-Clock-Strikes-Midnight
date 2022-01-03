using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResultsScreen : MonoBehaviour
{
    public float timeBeforeQuit;

    public TMP_Dropdown dropdown;
    public TextMeshProUGUI result;
    public float resultsFadeInTime;
    public Image coverImage;
    public string correctAnswer;
    public bool thereIsCorrectAnswer = true;

    public string victoryMessage;
    public string defeatMessage;

    private void Start()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CheckResults()
    {
        StartCoroutine(fadeOut());
    }

    IEnumerator fadeOut()
    {
        coverImage.gameObject.SetActive(true);
        float count = 0;
        Color col;
        col = coverImage.color;
        Color col2 = result.color;
        while (count < resultsFadeInTime)
        {
            col.a = Mathf.InverseLerp(0, resultsFadeInTime, count);
            coverImage.color = col;
            col2.a = col.a;
            result.color = col2;
            yield return null;
            count += Time.deltaTime;
        }
        col.a = 1;
        coverImage.color = col;
        col2.a = col.a;
        result.color = col2;

        if (!thereIsCorrectAnswer || dropdown.options[dropdown.value].text == correctAnswer)
        {
            result.text = victoryMessage;
        }
        else
        {
            result.text = defeatMessage;
        }

        yield return new WaitForSeconds(timeBeforeQuit);

        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class SubtitleManager : MonoBehaviour
{
    public static SubtitleManager Instance;
    public float secondPerCharacter;
    public float minimumSecondsBeforeDestruction;
    public float secondsPerWord;
    public string preface;
    public TextMeshProUGUI textDisplay;
    Coroutine currentWriteup;
    Queue<string> stringQueue = new Queue<string>();
    bool displayingMessage = false;
    public UnityEngine.Events.UnityEvent OnMessageCleared;
    public UnityEngine.Events.UnityEvent OnMessageFinished;
    public bool clearOnFinish = true;

    [Header("Pause")]
    public bool WaitForClick = false;
    private bool textPaused = false;
    public UnityEngine.Events.UnityEvent OnPaused;
    public UnityEngine.Events.UnityEvent OnUnpaused;
    public bool pauseOnLastString = false;

    public void SetTextPause(bool to)
    {
        textPaused = to;

        if (to) 
            OnPaused.Invoke();
        else 
            OnUnpaused.Invoke();
    }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        //secondsBeforeDestruction = PlayerPrefs.GetFloat("subtitleCooldown", secondsBeforeDestruction);
    }

    public void DisplayMessage(string msg, bool interrupt = false)
    {
        if (interrupt)
        {
            ClearMessages();
            ClearQueue();
            currentWriteup = StartCoroutine(writeMessage(msg));
        }
        else
        {

            if (!displayingMessage)
            {
                if (currentWriteup != null)
                    StopCoroutine(currentWriteup);
                displayingMessage = false;

                currentWriteup = StartCoroutine(writeMessage(msg));
            }
            else
            { 
                if (!stringQueue.Contains(msg))
                    stringQueue.Enqueue(msg);
            }
        }
    }

    /*
     
     */

    public void ContinueQueue()
    {
        if (stringQueue.Count > 0)
        {
            DisplayMessage(stringQueue.Dequeue());
        }
        else
        {
            ClearMessages(clearOnFinish);
        }
    }

    public void ClearMessages(bool clearText = true)
    {
        if (currentWriteup != null)
            StopCoroutine(currentWriteup);

        if (clearText)
            textDisplay.text = string.Empty;
        
        displayingMessage = false;
        OnMessageCleared.Invoke();

        if (stringQueue.Count == 0)
            OnMessageFinished.Invoke();
    }

    public void ClearQueue()
    {
        stringQueue.Clear();
    }

    IEnumerator writeMessage(string msg, bool continueQueue = true)
    {
        displayingMessage = true;
        int count = -1;
        string displayString = string.Empty;
        StringBuilder builder = new StringBuilder(displayString, msg.Length + 2);

        msg = msg.Replace("~", "\n");

        if (msg.Contains(":"))
        {
            string[] strs = msg.Split(':');
            preface = string.Format("<b>{0}:</b> ", strs[0]);
            msg = strs[1];
        }
        else
        {
            preface = "";
        }

        builder.Append(preface);

        while (count < msg.Length - 1)
        {
            while (textPaused)
            {
                yield return new WaitForEndOfFrame();
            }

            textDisplay.text = builder.ToString();
            yield return new WaitForSeconds(secondPerCharacter);

            do
            {
                count++;
                builder.Append(msg[count]);

            } while (count < msg.Length - 1 && !char.IsLetterOrDigit(msg[count]));
        }
        textDisplay.text = builder.ToString();

        if (WaitForClick && (pauseOnLastString || stringQueue.Count > 0))
        {
            SetTextPause(true);

            while (textPaused)
            {
                yield return new WaitForEndOfFrame();
            }
        }
        else if (stringQueue.Count > 0 || clearOnFinish)
        {
            yield return new WaitForSeconds(Mathf.Max(
                    minimumSecondsBeforeDestruction,
                    secondsPerWord * countWords(msg))
                );
        }

        ClearMessages(clearOnFinish);

        if (continueQueue && stringQueue.Count > 0)
        {
            ContinueQueue();
        }
    }

    int countWords(string text)
    {
        int wordCount = 0, index = 0;

        // skip whitespace until first word
        while (index < text.Length && char.IsWhiteSpace(text[index]))
            index++;

        while (index < text.Length)
        {
            // check if current char is part of a word
            while (index < text.Length && !char.IsWhiteSpace(text[index]))
                index++;

            wordCount++;

            // skip whitespace until next word
            while (index < text.Length && char.IsWhiteSpace(text[index]))
                index++;
        }

        return wordCount;
    }
}

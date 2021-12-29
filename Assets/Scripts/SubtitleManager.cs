using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class SubtitleManager : MonoBehaviour
{
    public static SubtitleManager Instance;
    public float secondPerCharacter;
    public float secondsBeforeDestruction;
    public TextMeshProUGUI textDisplay;
    Coroutine currentWriteup;
    Queue<string> stringQueue = new Queue<string>();
    bool displayingMessage;
    public UnityEngine.Events.UnityEvent OnMessageCleared;

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
                ClearMessages();
                currentWriteup = StartCoroutine(writeMessage(msg));
            }
            else
            {
                if (!stringQueue.Contains(msg))
                    stringQueue.Enqueue(msg);
            }
        }
    }

    public void ContinueQueue()
    {
        if (stringQueue.Count > 0)
        {
            DisplayMessage(stringQueue.Dequeue());
        }
        else
        {
            ClearMessages();
        }
    }

    public void ClearMessages()
    {
        if (currentWriteup != null)
            StopCoroutine(currentWriteup);
        textDisplay.text = string.Empty;
        displayingMessage = false;
        OnMessageCleared.Invoke();
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

        while (count < msg.Length - 1)
        {
            textDisplay.text = builder.ToString();
            yield return new WaitForSeconds(secondPerCharacter);

            do
            {
                count++;
                builder.Append(msg[count]);

            } while (count < msg.Length - 1 && !char.IsLetterOrDigit(msg[count]));
        }
        textDisplay.text = builder.ToString();

        yield return new WaitForSeconds(secondsBeforeDestruction);

        ClearMessages();

        if (continueQueue && stringQueue.Count > 0)
        {
            ContinueQueue();
        }
    }
}

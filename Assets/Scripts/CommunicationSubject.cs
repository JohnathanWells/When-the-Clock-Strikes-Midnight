using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Ink.Runtime;

public class CommunicationSubject : MonoBehaviour
{
    public TextAsset conversation;
    [HideInInspector]
    public Story story;
    public UnityEvent OnConversationStart;
    public UnityEvent OnConversationEnd;

    public void StartConversation()
    {
        story = new Story(conversation.text);

        OnConversationStart.Invoke();
        CommunicationManager.Instance.LoadSubject(this);
        CommunicationManager.Instance.StartConversation();
    }

    public void EndConversation()
    {
        OnConversationEnd.Invoke();
    }
}

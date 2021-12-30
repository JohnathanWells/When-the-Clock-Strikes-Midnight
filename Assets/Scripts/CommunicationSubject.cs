using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CommunicationSubject : MonoBehaviour
{
    public TextAsset conversation;
    public UnityEvent OnConversationStart;
    public UnityEvent OnConversationEnd;

    public void StartConversation()
    {
        OnConversationStart.Invoke();
        CommunicationManager.Instance.LoadSubject(this);
        CommunicationManager.Instance.StartConversation();
    }

    public void EndConversation()
    {
        OnConversationEnd.Invoke();
    }
}

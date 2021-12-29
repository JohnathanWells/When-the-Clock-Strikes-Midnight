using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableSubscriberScript : MonoBehaviour
{
    [System.Serializable]
    public class EventMessage
    {
        public enum Type { All, AtLeastMinimum};

        public string message;
        [SerializeField]
        private Type publishersRequired;
        public int MinimumCalls;
        public UnityEvent OnTrigger;

        EventMessage()
        {
            if (publishersRequired == Type.All)
            {
                MinimumCalls = 0;
            }
        }

        public void PublisherRegistered()
        {
            switch (publishersRequired)
            {
                case Type.All:
                    MinimumCalls++;
                    break;
                default:
                    break;
            }
        }
    }
    public string subscribeToTag;
    public static Dictionary<string, HashSet<InteractableScript>> publishers;
    public static Dictionary<string, HashSet<InteractableSubscriberScript>> subscribers;

    public EventMessage[] triggerMessages = new EventMessage[0];

    public UnityEvent OnPublisherDetected;
    bool publisherDetected = false;


    // Start is called before the first frame update
    //void Awake()
    //{
    //    InteractableSubscriberScript.AddSubscriber(subscribeToTag, this);
    //}
    void Awake()
    {
        InteractableSubscriberScript.AddSubscriber(subscribeToTag, this);
    }

    public void Trigger(string withMessage)
    { 
        for (int n = 0; n < triggerMessages.Length; n++)
        {
            if (triggerMessages[n].message.Trim() == withMessage.Trim())
            {
                triggerMessages[n].MinimumCalls--;

                if (triggerMessages[n].MinimumCalls <= 0)
                    triggerMessages[n].OnTrigger.Invoke();
            }
        }
    }

    public void UpdateMinimumPublisherCount(string withMessage)
    {
        for (int n = 0; n < triggerMessages.Length; n++)
        {
            if (triggerMessages[n].message.Trim() == withMessage.Trim())
            {
                triggerMessages[n].PublisherRegistered();
            }
        }
    }

    public static void AddSubscriber(string tag, InteractableSubscriberScript to)
    {
        if (subscribers == null)
        {
            subscribers = new Dictionary<string, HashSet<InteractableSubscriberScript>>();
        }

        if (subscribers.TryGetValue(tag, out var temp))
        {
            temp.Add(to);
        }
        else
        {
            HashSet<InteractableSubscriberScript> newSet = new HashSet<InteractableSubscriberScript>();
            newSet.Add(to);
            subscribers.Add(tag, newSet);
        }
    }

    public static void AddPublisher(string tag, InteractableScript to)
    {
        if (publishers == null)
        {
            publishers = new Dictionary<string, HashSet<InteractableScript>>();
        }

        if (publishers.TryGetValue(tag, out var temp))
        {
            temp.Add(to);
        }
        else
        {
            HashSet<InteractableScript> newSet = new HashSet<InteractableScript>();
            newSet.Add(to);
            publishers.Add(tag, newSet);
        }

        if (subscribers.TryGetValue(tag, out var tempS))
        {
            foreach (var i in tempS)
            {
                i.UpdateMinimumPublisherCount(to.messageOnPublish);
            }
        }

        foreach (KeyValuePair<string, HashSet<InteractableSubscriberScript>> t in subscribers)
        {
            foreach (var s in subscribers[t.Key])
            {
                s.NotifyOfNewPublisher(to);
            }
        }
        Debug.Log("Publisher added for " + tag);
    }

    public static void TriggerWithTag(string tag, string message)
    {
        if (subscribers.TryGetValue(tag, out var temp))
        {
            foreach (var i in temp)
            {
                i.Trigger(message);
            }
        }
    }

    public void NotifyOfNewPublisher(InteractableScript script)
    {
        if (!publisherDetected)
        {
            OnPublisherDetected.Invoke();
            publisherDetected = true;
        }
    }

    //public void NotifyOfNewSubscriber(InteractableSubscriberScript script)
    //{
    //    if (!publisherDetected)
    //    {
    //        OnPublisherDetected.Invoke();
    //        publisherDetected = true;
    //    }
    //}

    public static void ClearPublishers()
    {
        if (publishers != null)
            publishers.Clear();
    }

    public static void ClearSubscribers()
    {
        if (subscribers != null)
            subscribers.Clear();
    }
}

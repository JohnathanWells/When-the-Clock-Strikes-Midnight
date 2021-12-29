using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublisherScript : MonoBehaviour
{
    public string[] tags;

    public void PublishMessage(string msg)
    {
        foreach (var s in tags)
        {
            InteractableSubscriberScript.TriggerWithTag(s, msg);
        }
    }
}

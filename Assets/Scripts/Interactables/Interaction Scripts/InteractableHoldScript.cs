using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableHoldScript : InteractableScript
{
    public string[] tags;
    //public string messageOnPublish;
    public UnityEvent OnStartInteracting;
    public UnityEvent OnInteracting;
    public UnityEvent OnStopInteracting;
    [SerializeField]
    bool interacting = false;

    // Start is called before the first frame update
    void Init()
    {
        foreach (var s in tags)
        {
            InteractableSubscriberScript.AddPublisher(s, this);
        }
    }

    public override void StartInteracting(PlayerInteractiveScript player)
    {
        interacting = true;
        OnStartInteracting.Invoke();
    }

    public override void Interact(PlayerInteractiveScript player)
    {
        OnInteracting.Invoke();
    }

    public override void StopInteracting(PlayerInteractiveScript player)
    {
        interacting = false;
        OnStopInteracting.Invoke();
    }

    public void TriggerTags()
    {
        foreach (var s in tags)
        {
            InteractableSubscriberScript.TriggerWithTag(s, messageOnPublish);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableButtonScript : InteractableScript
{
    public bool ENABLED = true;
    public string[] tags;
    //public string messageOnPublish;
    public UnityEvent OnTrigger;
    public UnityEvent OnTriggerUp;

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
        if (ENABLED)
        {
            foreach (var s in tags)
            {
                InteractableSubscriberScript.TriggerWithTag(s, messageOnPublish);
            }
            OnTrigger.Invoke();
        }
    }

    public override void Interact(PlayerInteractiveScript player)
    {
    }

    public override void StopInteracting(PlayerInteractiveScript player)
    {
        //if (ENABLED)
        //{
        //    //foreach (var s in tags)
        //    //{
        //    //    InteractableSubscriberScript.TriggerWithTag(s, messageOnPublish);
        //    //}
        //    OnTriggerUp.Invoke();
        //}
    }

    public void Disable()
    {
        ENABLED = false;
    }

    public void Enable()
    {
        ENABLED = true;
    }
}

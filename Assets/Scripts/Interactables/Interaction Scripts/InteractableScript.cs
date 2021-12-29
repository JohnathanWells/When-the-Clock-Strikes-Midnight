using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableScript : MonoBehaviour
{
    public string messageOnPublish;
    public abstract void Interact(PlayerInteractiveScript player);
    public abstract void StartInteracting(PlayerInteractiveScript player);
    public abstract void StopInteracting(PlayerInteractiveScript player);
}

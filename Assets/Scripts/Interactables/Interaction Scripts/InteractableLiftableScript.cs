using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableLiftableScript : InteractableScript
{
    public Rigidbody reggiebody;
    public bool pickedUp = false;
    private bool kinematicProperty;
    private bool gravityProperty;
    private Transform originalParent;

    public override void Interact(PlayerInteractiveScript player)
    {
    }

    public override void StartInteracting(PlayerInteractiveScript player)
    {
        if (!pickedUp)
        {
            kinematicProperty = reggiebody.isKinematic;
            gravityProperty = reggiebody.useGravity;
            originalParent = transform.parent;

            transform.parent = player.pickUpPoint;
            transform.localPosition = Vector3.zero;
            reggiebody.isKinematic = true;
            reggiebody.useGravity = false;

            pickedUp = true;
        }
        else
        {
            transform.parent = originalParent;
            reggiebody.isKinematic = kinematicProperty;
            reggiebody.useGravity = gravityProperty;

            pickedUp = false;
        }

    }

    public override void StopInteracting(PlayerInteractiveScript player)
    {

    }
}

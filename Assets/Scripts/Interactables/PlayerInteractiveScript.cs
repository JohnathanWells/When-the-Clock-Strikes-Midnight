using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteractiveScript : MonoBehaviour
{
    public LayerMask blockingLayers;
    public float interactiveRange;
    public float interactiveRadius;
    InteractableScript activeComponent;
    public UnityEvent OnInteractDown;
    public UnityEvent OnInteractUp;

    [Header("Pick up")]
    public Transform pickUpPoint;

    RaycastHit[] hits;

    private void Update()
    {
        if (Input.GetButtonDown("Use"))
        {

            //if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out info, interactiveRange, blockingLayers))
            if ((hits = Physics.SphereCastAll(Camera.main.transform.position, interactiveRadius, Camera.main.transform.forward, interactiveRange, blockingLayers)).Length > 0)
            {
                foreach (var info in hits)
                {
                    currentHitDistance = info.distance;
                    InteractableScript interactable;

                    if (info.transform.TryGetComponent<InteractableScript>(out interactable))
                    {
                        activeComponent = interactable;

                        OnInteractDown.Invoke();

                        interactable.StartInteracting(this);
                        break;
                    }
                }
            }
            else
            {
                currentHitDistance = interactiveRange;
            }
        }
        else if (Input.GetButtonUp("Use"))
        {
            if (activeComponent)
            {
                OnInteractUp.Invoke();

                activeComponent.StopInteracting(this);
                activeComponent = null;
            }
        }
        else if (activeComponent)
        {

            //if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out info, interactiveRange, blockingLayers))
            if ((hits = Physics.SphereCastAll(Camera.main.transform.position, interactiveRadius, Camera.main.transform.forward, interactiveRange, blockingLayers)).Length > 0)
            {
                foreach (var info in hits)
                {
                    currentHitDistance = info.distance;

                    if (activeComponent != null && info.transform == activeComponent.transform)
                    {
                        activeComponent.Interact(this);
                    }
                    else 
                    {
                        OnInteractUp.Invoke();

                        if (activeComponent != null)
                            activeComponent.StopInteracting(this);
                        activeComponent = null;
                    }
                }
            }
            else
            {
                currentHitDistance = interactiveRange;

                OnInteractUp.Invoke();

                if (activeComponent != null)
                    activeComponent.StopInteracting(this);

                activeComponent = null;
            }
        }
        else
        {

            //if ((hits = Physics.SphereCastAll(Camera.main.transform.position, interactiveRadius, Camera.main.transform.forward, interactiveRange, blockingLayers)).Length > 0)
            //{
            //    print("Hit");
            //}
            //else
            //{
            //    print("Nothing");
            //    currentHitDistance = interactiveRange;
            //}
        }
    }

    private float currentHitDistance;
    private void OnDrawGizmos()
    {
        Vector3 origin = Camera.main.transform.position;
        Vector3 direction = Camera.main.transform.forward;
        Gizmos.color = Color.red;
        Debug.DrawLine(origin, origin + direction * currentHitDistance, Color.red);
        Gizmos.DrawWireSphere(origin + direction * currentHitDistance, interactiveRadius);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ActivateThings : MonoBehaviour
{
    public void ActivateButtonEventStatus()
    {
        Debug.Log("Activating ButtonEventStatus on " + this.gameObject.name);
        ButtonEventStatus bes;

        if (this.gameObject.TryGetComponent<ButtonEventStatus>(out bes))
        {
            bes.enabled = true;
        }
    }

    public void DeactivateButtonEventStatus()
    {
        Debug.Log("Deactivating ButtonEventStatus on " + this.gameObject.name);
        ButtonEventStatus bes;

        if (this.gameObject.TryGetComponent<ButtonEventStatus>(out bes))
        {
            bes.enabled = false;
        }
    }

    public void ActivateInteractable()
    {
        Debug.Log("Activating Interactable on " + this.gameObject.name);
        Interactable ia;

        if (this.gameObject.TryGetComponent<Interactable>(out ia))
        {
            ia.enabled = true;
        }
    }

    public void DeactivateInteractable()
    {
        Debug.Log("Deactivating Interactable on " + this.gameObject.name);
        Interactable ia;

        if (this.gameObject.TryGetComponent<Interactable>(out ia))
        {
            ia.enabled = false;
        }
    }

    public void ActivateCollider()
    {
        Debug.Log("Activating Collider on " + this.gameObject.name);
        Collider c;

        if (this.gameObject.TryGetComponent<Collider>(out c))
        {
            c.enabled = true;
        }
    }

    public void DeactivateCollider()
    {
        Debug.Log("Deactivating Collider on " + this.gameObject.name);
        Collider c;

        if (this.gameObject.TryGetComponent<Collider>(out c))
        {
            c.enabled = false;
        }
    }
}

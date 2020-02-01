using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Interactable))]
public class ButtonEventStatus : MonoBehaviour
{
    public SteamVR_Action_Boolean grabPinch;
    public bool InitialButtonStatus;
    private Interactable interactable;
    bool ButtonStatus;
    bool highlighted;
    SteamVR_Input_Sources inputSourceRight = SteamVR_Input_Sources.RightHand;
    SteamVR_Input_Sources inputSourceLeft = SteamVR_Input_Sources.LeftHand;

    public GameObject syncedGo;


    // Start is called before the first frame update
    void Start()
    {
        interactable = this.gameObject.GetComponent<Interactable>();
        ButtonStatus = InitialButtonStatus;

        if (syncedGo != null)
        {
            syncedGo.SetActive(ButtonStatus);
        }
    }

    void Update()
    {
        highlighted = interactable.isHovering;
    }

    void OnEnable()
    {
        if (grabPinch != null)
        {
            grabPinch.AddOnChangeListener(OnTriggerPressedOrReleased, inputSourceLeft);
            grabPinch.AddOnChangeListener(OnTriggerPressedOrReleased, inputSourceRight);
        }
    }

    private void OnDisable()
    {
        if (grabPinch != null)
        {
            grabPinch.RemoveOnChangeListener(OnTriggerPressedOrReleased, inputSourceLeft);
            grabPinch.RemoveOnChangeListener(OnTriggerPressedOrReleased, inputSourceRight);
        }
    }



    private void OnTriggerPressedOrReleased(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource, bool newState)
    {
        if (highlighted && fromSource == interactable.hoveringHand.handType)
        {
            if (newState)
            {
                Debug.Log("Trigger was pressed on: " + this.gameObject.name + " - " + fromSource);
                ButtonStatus = !ButtonStatus;
                if (syncedGo != null)
                {
                    syncedGo.SetActive(ButtonStatus);
                }

            }
            else
            {
                Debug.Log("Trigger was released on: " + this.gameObject.name + " - " + fromSource);
            }
        }
    }
}

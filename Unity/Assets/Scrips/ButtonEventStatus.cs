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

    public GameObject[] syncedGo;
    public GameObject[] syncedInvertedGo;

    public GameState dependsOnGameState;

    public HandEvent Blub;

    // Start is called before the first frame update
    void Start()
    {
        interactable = this.gameObject.GetComponent<Interactable>();
        ButtonStatus = InitialButtonStatus;

        GameController.Instance.RegisterStateObject(this.gameObject);

        UpdateSyncedGos();
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

    private void UpdateSyncedGos()
    {
        if (syncedGo != null && syncedGo.Length > 0)
        {
            foreach (var go in syncedGo)
            {
                if (go != null)
                    go.SetActive(ButtonStatus);
            }
        }
        if (syncedInvertedGo != null && syncedInvertedGo.Length > 0)
        {
            foreach (var go in syncedInvertedGo)
            {
                if (go != null)
                    go.SetActive(!ButtonStatus);
            }
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

                UpdateSyncedGos();

                Blub.Invoke(interactable.hoveringHand);

            }
            else
            {
                Debug.Log("Trigger was released on: " + this.gameObject.name + " - " + fromSource);
            }
        }
    }
}

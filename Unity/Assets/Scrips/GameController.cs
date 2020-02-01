using System;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance = null;

    private List<GameObject> StateObjects = new List<GameObject>();

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public GameState CurrentGameState { get; private set; } = GameState.Start;

    public void RegisterStateObject(GameObject go)
    {
        StateObjects.Add(go);

        UpdateStateObjects();
    }

    public void AdvanceGameState()
    {
        var id = (int)CurrentGameState;
        CurrentGameState = (GameState)(id + 1);

        UpdateStateObjects();

        Debug.Log("Advanced GameState to: " + CurrentGameState);
    }

    public void SetGameState(GameState gs)
    {
        CurrentGameState = gs;

        UpdateStateObjects();

        Debug.Log("Set GameState to: " + CurrentGameState);
    }
    public void SetGameState(string gss)
    {
        GameState myStatus = GameState.None;
        Enum.TryParse("Active", out myStatus);

        CurrentGameState = myStatus;

        UpdateStateObjects();

        Debug.Log("Set GameState to: " + CurrentGameState);
    }

    private void UpdateStateObjects()
    {
        foreach (var go in StateObjects)
        {
            var button = go.GetComponent<ButtonEventStatus>();
            if (button != null)
            {
                if ((int)button.dependsOnGameState < 0 || button.dependsOnGameState == CurrentGameState)
                {
                    button.enabled = true;
                }
                else
                {
                    button.enabled = false;
                }
            }

        }
    }


}

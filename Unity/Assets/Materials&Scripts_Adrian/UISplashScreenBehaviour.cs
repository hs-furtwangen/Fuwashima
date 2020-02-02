using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UISplashScreenBehaviour : MonoBehaviour
{
    public enum ScreenTitles { Title, Instruction1, Instruction2, Instruction3}

    private Button instructionStartButton = null;
    public Button[] allOtherButtons;

    // Start is called before the first frame update
    void Start()
    {
        allOtherButtons = GetComponentsInChildren<Button>();
        instructionStartButton = this.transform.GetChild(0).GetChild(2).GetComponent<Button>();
        instructionStartButton.onClick.AddListener(openFirstInstructionPanel);

        for (int i = 0; i < this.transform.childCount; i++)
        {
            if (i == 0)
            {
                this.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                this.transform.GetChild(i).gameObject.SetActive(false);
            }
            
        }
    }

    public void screenSwitcher(ScreenTitles incomingScreenTitle)
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            this.transform.GetChild(i).gameObject.SetActive(false);
        }

        this.transform.GetChild((int)incomingScreenTitle).gameObject.SetActive(true);
    }

    public void openFirstInstructionPanel()
    {
        screenSwitcher(ScreenTitles.Instruction1);
    }

    public void openSecondInstructionPanel()
    {
        screenSwitcher(ScreenTitles.Instruction2);
    }

    public void openThirdInstructionPanel()
    {
        screenSwitcher(ScreenTitles.Instruction3);
    }

    public void StartGame()
    {
        //Loads the game scene
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameUI : MonoBehaviour
{
    public Button StartGameBtn;
    public Button TutorialBtn;
    public Button OptionsBtn;
    
    
    public GameObject LevelSelect;
    public GameObject optionsMenu;
    public GameObject tutorialPanel;
    
    private void Awake()
    {
        LevelSelect.SetActive(false);
        optionsMenu.SetActive(false);
        tutorialPanel.SetActive(false);
    }

    public void ToggleLevelSelect(bool isShow)
    {
        LevelSelect.gameObject.SetActive(isShow);
    }

    public void ToggleTutorial(bool isShow)
    {
        optionsMenu.gameObject.SetActive(isShow);
    }

    public void ToggleOptions(bool isShow)
    {
        tutorialPanel.gameObject.SetActive(isShow);
    }
}

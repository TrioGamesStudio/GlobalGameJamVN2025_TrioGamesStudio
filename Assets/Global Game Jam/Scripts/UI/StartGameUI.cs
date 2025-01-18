using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameUI : MonoBehaviour
{
    public Button StartGameBtn;
    public Button TutorialBtn;
    public Button OptionsBtn;
    public Button ReturnBtn;
    public Button ExitBtn;
    public CanvasGroup LevelSelect;
    public CanvasGroup MainMenu;

    private void Awake()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            ExitBtn.gameObject.SetActive(false);
        }        
        ExitBtn.onClick.AddListener(QuitGame);
        SetStateCanvas(LevelSelect, false);
        SetStateCanvas(MainMenu, true);
    }

    private void OnDestroy()
    {
        ExitBtn.onClick.RemoveListener(QuitGame);
    }


    public void ToggleLevelSelect(bool isShow)
    {
        SetStateCanvas(LevelSelect, isShow);
        SetStateCanvas(MainMenu, !isShow);

    }

    private void SetStateCanvas(CanvasGroup canvasGroup, bool isShow)
    {
        canvasGroup.alpha = isShow ? 1 : 0;
        canvasGroup.interactable = isShow;
        canvasGroup.blocksRaycasts = isShow;
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}

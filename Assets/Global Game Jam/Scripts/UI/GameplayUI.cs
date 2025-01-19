using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;
public class GameplayUI : MonoBehaviour
{
    [SerializeField] private GameObject ResultPanel;
    [SerializeField] private GameObject gameplayPanel;
    [Header("Menu Button")]
    [SerializeField] private Button replayBtn;
    [SerializeField] private Button menuBtn;
    [SerializeField] private Button levelSelectBtn;
    [SerializeField] private ResultGameUI ResultGameUI;
    [SerializeField] private SoundData winGameSound;
    [SerializeField] private SoundData losseGameSound;
    private void Awake()
    {
        ResultGameUI = GetComponentInChildren<ResultGameUI>();
        ResultPanel.gameObject.SetActive(false);
        replayBtn.onClick.AddListener(ReplayGame);
        menuBtn.onClick.AddListener(MainMenuScene);
    }

    public void OnShowResultTable(bool isWin)
    {
        ResultGameUI.gameObject.SetActive(true);
        gameplayPanel.gameObject.SetActive(false);
        if (isWin)
        {
            ResultGameUI.Complete();
            winGameSound.PlayTest();
        }
        else
        {
            ResultGameUI.Loose();
            losseGameSound.PlayTest();
        }
    }
    
    [Button]
    private void ReplayGame()
    {
        TestLoadScene.Instance.Load(TestLoadScene.LEVEL_SCENE+DataManager.currentMapLevelData.level);
    }
    
    [Button]
    private void MainMenuScene()
    {
        TestLoadScene.Instance.Load(TestLoadScene.MENU_SCENE);
    }

    [Button]
    private void WinTest()
    {
        OnShowResultTable(true);
    }
}
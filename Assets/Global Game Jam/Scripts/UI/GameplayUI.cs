using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;
public class GameplayUI : MonoBehaviour
{
    [SerializeField] private GameObject ResultPanel;

    [Header("Menu Button")]
    [SerializeField] private Button replayBtn;
    [SerializeField] private Button menuBtn;
    [SerializeField] private Button levelSelectBtn;
    

    private void Awake()
    {
        ResultPanel.gameObject.SetActive(false);
        replayBtn.onClick.AddListener(ReplayGame);
        menuBtn.onClick.AddListener(MainMenuScene);
    }
    
    [Button]
    private void ReplayGame()
    {
        TestLoadScene.Instance.Load(TestLoadScene.LEVEL_SCENE);
    }
    
    [Button]
    private void MainMenuScene()
    {
        TestLoadScene.Instance.Load(TestLoadScene.MENU_SCENE);
    }
}
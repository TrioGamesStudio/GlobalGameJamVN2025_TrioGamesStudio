using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    public MapLevelData MapLevelData;
    public Button playGameButton;
    public TextMeshProUGUI collectText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI collectBubbleText;
    public TextMeshProUGUI levelText;
    public int totalCollect = 3;
    public int totalBubbleCollect = 3;
    public int level = 1;
    private void Awake()
    {
        totalCollect = MapLevelData.maxDiamond;
        totalBubbleCollect = MapLevelData.maxBubble;
        
        LoadTrophiesCollect();
        LoadTime();
        LoadTrophiesBubbleCollect();
        playGameButton.onClick.AddListener(OnPlayGame);
        levelText.text = "Level " + level;
    }

    private void OnPlayGame()
    {
        DataManager.CurrentLevel = level;
        DataManager.TotalTime = 0;
        DataManager.TotalDiamondCollected = 0;
        DataManager.currentMapLevelData = MapLevelData;
        TestLoadScene.Instance.Load(TestLoadScene.LEVEL_SCENE);
    }
    
    [Button]
    private void LoadTrophiesCollect()
    {
        int collected = 0;
        if (PlayerPrefs.HasKey(DataManager.TROPHIES_COLLECT))
        {
            collected = PlayerPrefs.GetInt(DataManager.TROPHIES_COLLECT + level);
        }
        collectText.text = $"{collected} / {totalCollect}";
    }
    
    [Button]
    private void LoadTime()
    {
        int time = 0;
        if (PlayerPrefs.HasKey(DataManager.TIME_COMPLETE))
        {
            time = PlayerPrefs.GetInt(DataManager.TIME_COMPLETE + level);
        }

        timerText.text = ClockUI.FormatTime(time);
    }
    private void LoadTrophiesBubbleCollect()
    {
        int collected = 0;
        if (PlayerPrefs.HasKey(DataManager.TROPHIES_BUBBLE_COLLECT))
        {
            collected = PlayerPrefs.GetInt(DataManager.TROPHIES_BUBBLE_COLLECT + level);
        }
        collectBubbleText.text = $"{collected} / {totalBubbleCollect}";
    }

    
}
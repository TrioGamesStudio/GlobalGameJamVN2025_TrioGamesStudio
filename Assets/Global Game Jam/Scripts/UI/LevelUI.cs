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

    private void Awake()
    {
        totalCollect = MapLevelData.maxDiamond;
        totalBubbleCollect = MapLevelData.maxBubble;

        LoadTrophiesCollect();
        LoadTime();
        LoadTrophiesBubbleCollect();
        playGameButton.onClick.AddListener(OnPlayGame);
        levelText.text = "Level " + MapLevelData.level;
    }

    private void OnPlayGame()
    {
        DataManager.TotalTime = 0;
        DataManager.TotalDiamondCollected = 0;
        DataManager.currentMapLevelData = MapLevelData;
        TestLoadScene.Instance.Load(TestLoadScene.LEVEL_SCENE + MapLevelData.level);
        BackgroundMusic.Instance.StopMusic();
    }

    [Button]
    private void LoadTrophiesCollect()
    {
        int collected = 0;
        string key = DataManager.TROPHIES_COLLECT + MapLevelData.level;
        if (PlayerPrefs.HasKey(key))
        {
            collected = PlayerPrefs.GetInt(key);
        }

        collectText.text = $"{collected} / {totalCollect}";
    }

    [Button]
    private void LoadTime()
    {
        int time = 0;
        string key = DataManager.TIME_COMPLETE + MapLevelData.level;

        if (PlayerPrefs.HasKey(key))
        {
            time = PlayerPrefs.GetInt(key);
        }

        timerText.text = ClockUI.FormatTime(time);
    }

    private void LoadTrophiesBubbleCollect()
    {
        int collected = 0;
        string key = DataManager.TROPHIES_BUBBLE_COLLECT + MapLevelData.level;

        if (PlayerPrefs.HasKey(key))
        {
            collected = PlayerPrefs.GetInt(key);
        }

        collectBubbleText.text = $"{collected} / {totalBubbleCollect}";
    }
}
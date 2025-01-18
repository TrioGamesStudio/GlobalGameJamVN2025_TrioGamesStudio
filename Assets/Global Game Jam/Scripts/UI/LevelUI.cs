using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    public Button playGameButton;
    public TextMeshProUGUI collectText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI levelText;
    public int total = 3;
    public int level = 1;
    private void Awake()
    {
        LoadTrophiesCollect();
        LoadTime();
        playGameButton.onClick.AddListener(OnPlayGame);
        levelText.text = "Level " + level;
    }

    private void OnPlayGame()
    {
        DataManager.CurrentLevel = level;
        DataManager.TotalTime = 0;
        DataManager.TotalCollected = 0;
        
        TestLoadScene.Instance.Load(TestLoadScene.LEVEL_SCENE);
    }
    
    [Button]
    private void LoadTrophiesCollect()
    {
        int collected = 0;
        if (PlayerPrefs.HasKey("TROPHIES_COLLECT"))
        {
            collected = PlayerPrefs.GetInt(DataManager.TROPHIES_COLLECT + level);
        }
        collectText.text = $"{collected} / {total}";
    }
    
    [Button]
    private void LoadTime()
    {
        int time = 0;
        if (PlayerPrefs.HasKey("TIME_SAVE"))
        {
            time = PlayerPrefs.GetInt(DataManager.TIME_COMPLETE + level);
        }

        timerText.text = FormatTime(time);
    }
    
    string FormatTime(int totalSeconds)
    {
        int minutes = totalSeconds / 60; 
        int seconds = totalSeconds % 60;
        return string.Format("{0}'{1}s", minutes, seconds);
    }
}
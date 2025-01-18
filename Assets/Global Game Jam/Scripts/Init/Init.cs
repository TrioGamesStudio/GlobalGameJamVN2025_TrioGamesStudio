using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    [Header("Game Logic")]
    [SerializeField] BubbleData bubbleData;

    [SerializeField] private BubbleWaveEffect bubbleWaveEffect;
    [SerializeField] private TimerManager timerManager;
    [Header("UI")]
    [SerializeField] UIHandler uIHandler;
    [SerializeField] private HealthManagerUI healthManagerUI;
    [SerializeField] private GameplayUI gameplayUI;
    [SerializeField] private DiamondUI diamondUI;
    [SerializeField] private ClockUI ClockUI;
    [SerializeField] private BubbleUI bubbleUI;
    [SerializeField] private MapLevelData defaultLevelData;
    private void Awake() {
        bubbleData.UpdateHealthAction_UIhandler += uIHandler.OnHealthUpdate;
        bubbleData.UpdateDiamondAction_UIhandler += uIHandler.OnDiamondUpdate;
        
        bubbleData.UpdateHealthAction_UIhandler += healthManagerUI.OnChangedHealth;
        bubbleData.UpdateDiamondAction_UIhandler += diamondUI.OnChangedDiamond;
        
        // timer
        timerManager.OnTimerChanged += ClockUI.UpdateTimer;
        //
        bubbleWaveEffect.OnChangedBubbleChild += bubbleUI.OnChangedBubble;

        bubbleData.OnShowResultTable += Save;

        InitHealthBar();
        if (DataManager.currentMapLevelData == null)
        {
            DataManager.currentMapLevelData = defaultLevelData;
        }
        
    }


    private void OnDisable() {
        bubbleData.UpdateHealthAction_UIhandler -= uIHandler.OnHealthUpdate;
        bubbleData.UpdateHealthAction_UIhandler -= healthManagerUI.OnChangedHealth;
        bubbleData.UpdateDiamondAction_UIhandler -= diamondUI.OnChangedDiamond;
        
        //timer
        timerManager.OnTimerChanged -= ClockUI.UpdateTimer;
        
        bubbleWaveEffect.OnChangedBubbleChild -= bubbleUI.OnChangedBubble;
        
        bubbleData.OnShowResultTable -= Save;
    }

    private void Save(bool state)
    {
        //Stop Timer        
        timerManager.OnStopTimer();
       // Saving Data
        DataManager.TotalDiamondCollected = bubbleData.GetDiamond();
        DataManager.TotalBubbleCollected = bubbleWaveEffect.GetBubbleCount();
        DataManager.TotalTime = timerManager.GetTimer();
        
        gameplayUI.OnShowResultTable(state);
        
        DataManager.Save();
        
        BackgroundMusic.Instance.StopMusic();
        
    }

    private void InitHealthBar()
    {
        healthManagerUI.Init(3);
        timerManager.OnStartTimer();
    }

}

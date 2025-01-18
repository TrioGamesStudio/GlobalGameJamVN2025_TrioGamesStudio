using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    [Header("Game Logic")]
    [SerializeField] BubbleData bubbleData;

    [SerializeField] private TimerManager timerManager;
    [Header("UI")]
    [SerializeField] UIHandler uIHandler;
    [SerializeField] private HealthManagerUI healthManagerUI;
    [SerializeField] private DiamondUI diamondUI;
    [SerializeField] private ClockUI ClockUI;
    private void Awake() {
        bubbleData.UpdateHealthAction_UIhandler += uIHandler.OnHealthUpdate;
        bubbleData.UpdateDiamondAction_UIhandler += uIHandler.OnDiamondUpdate;
        
        bubbleData.UpdateHealthAction_UIhandler += healthManagerUI.OnChangedHealth;
        bubbleData.UpdateDiamondAction_UIhandler += diamondUI.OnChangedDiamond;
        
        // timer
        timerManager.OnTimerChanged += ClockUI.UpdateTimer;
        
        InitHealthBar();
    }


    private void OnDisable() {
        bubbleData.UpdateHealthAction_UIhandler -= uIHandler.OnHealthUpdate;
        bubbleData.UpdateHealthAction_UIhandler -= healthManagerUI.OnChangedHealth;
        bubbleData.UpdateDiamondAction_UIhandler -= diamondUI.OnChangedDiamond;
        
        //timer
        timerManager.OnTimerChanged -= ClockUI.UpdateTimer;
    }


    private void InitHealthBar()
    {
        healthManagerUI.Init(3);
        timerManager.OnStartTimer();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    [SerializeField] BubbleData bubbleData;
    [SerializeField] UIHandler uIHandler;
    [SerializeField] private HealthManagerUI healthManagerUI;
    private void Awake() {
        bubbleData.UpdateHealthAction_UIhandler += uIHandler.OnHealthUpdate;
        bubbleData.UpdateDiamondAction_UIhandler += uIHandler.OnDiamondUpdate;
        bubbleData.UpdateHealthAction_UIhandler += healthManagerUI.OnChangedHealth;
        
        InitHealthBar();
    }


    private void OnDisable() {
        bubbleData.UpdateHealthAction_UIhandler -= uIHandler.OnHealthUpdate;
        bubbleData.UpdateHealthAction_UIhandler -= healthManagerUI.OnChangedHealth;
    }


    private void InitHealthBar()
    {
        healthManagerUI.Init(3);
    }
}

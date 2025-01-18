using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    [SerializeField] BubbleData bubbleData;
    [SerializeField] UIHandler uIHandler;

    private void Awake() {
        bubbleData.UpdateHealthAction_UIhandler += uIHandler.OnHealthUpdate;
    }


    private void OnDisable() {
        bubbleData.UpdateHealthAction_UIhandler -= uIHandler.OnHealthUpdate;
    }

}

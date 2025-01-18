using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    }
}
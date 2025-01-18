using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour
{
    public GameObject ResultPanel;

    [Header("Menu Button")]
    public Button replayBtn;
    public Button menuBtn;
    public Button levelSelectBtn;


    private void Awake()
    {
        ResultPanel.gameObject.SetActive(false);
    }
}

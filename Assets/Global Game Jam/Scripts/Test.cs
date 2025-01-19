using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class Test : MonoBehaviour
{
    public int total1;
    public int total2;

    public int total3;
    public MapLevelData sdasd;
    [Button]
    public void Save()
    {
        DataManager.currentMapLevelData = sdasd;
        DataManager.TotalBubbleCollected = total1;
        DataManager.TotalDiamondCollected = total2;
        DataManager.TotalTime = total3;
        DataManager.Save();
        
        Debug.Log(PlayerPrefs.HasKey(DataManager.TROPHIES_BUBBLE_COLLECT+sdasd.level));
        Debug.Log(PlayerPrefs.HasKey(DataManager.TIME_COMPLETE+sdasd.level));
        Debug.Log(PlayerPrefs.HasKey(DataManager.TROPHIES_COLLECT+sdasd.level));

    }
}

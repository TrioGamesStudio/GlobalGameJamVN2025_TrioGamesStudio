using UnityEngine;

public static class DataManager
{
    public static string TROPHIES_COLLECT = "TROPHIES_COLLECT_";
    public static string TIME_COMPLETE = "TIME_COMPLETE_";
    public static string TROPHIES_BUBBLE_COLLECT => "TROPHIES_BUBBLE_COLLECT_";
    public static int TotalDiamondCollected = 0;
    public static int TotalBubbleCollected = 0;
    public static int TotalTime = 0;
    public static MapLevelData currentMapLevelData;

    public static void Save()
    {
        SaveTrophies();
        // SaveTimeComplete();
        SaveBubbleTrophies();
    }

    public static void SaveTimeComplete()
    {
        string key = TIME_COMPLETE + currentMapLevelData.level;

        if (PlayerPrefs.HasKey(key))
        {
            var completeTime = PlayerPrefs.GetInt(key);

            if (TotalTime < completeTime)
            {
                PlayerPrefs.SetInt(key, TotalTime);
            }
        }
        else
        {
            PlayerPrefs.SetInt(key, TotalTime);
        }
    }

    private static void SaveTrophies()
    {
        string key = TROPHIES_COLLECT + currentMapLevelData.level;

        if (PlayerPrefs.HasKey(key))
        {
            var currentValue = PlayerPrefs.GetInt(key);

            if (TotalDiamondCollected > currentValue)
            {
                PlayerPrefs.SetInt(key, TotalDiamondCollected);
            }
        }
        else
        {
            PlayerPrefs.SetInt(key, TotalDiamondCollected);
        }
    }

    private static void SaveBubbleTrophies()
    {
        string key = TROPHIES_BUBBLE_COLLECT + currentMapLevelData.level;

        if (PlayerPrefs.HasKey(key))
        {
            var currentValue = PlayerPrefs.GetInt(key);

            if (TotalBubbleCollected > currentValue)
            {
                PlayerPrefs.SetInt(key, TotalBubbleCollected);
            }
        }
        else
        {
            PlayerPrefs.SetInt(key, TotalBubbleCollected);
        }
    }
}
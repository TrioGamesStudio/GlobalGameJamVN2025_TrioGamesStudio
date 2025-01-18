using UnityEngine;

public static class DataManager
{
    public const string TROPHIES_COLLECT = "TROPHIES_COLLECT_";
    public const string TIME_COMPLETE = "TIME_COMPLETE_";
    public const string TROPHIES_BUBBLE_COLLECT = "TROPHIES_BUBBLE_COLLECT";
    public static int CurrentLevel = 0;
    public static int TotalDiamondCollected = 0;
    public static int TotalBubbleCollected = 0;
    public static int TotalTime = 0;
    public static MapLevelData currentMapLevelData;
    public static void Save()
    {
        SaveTrophies();
        SaveTimeComplete();
        SaveBubbleTrophies();
    }

    private static void SaveTimeComplete()
    {
        string key = TIME_COMPLETE + CurrentLevel;

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
            PlayerPrefs.SetInt(key,TotalTime);
        }
    }

    private static void SaveTrophies()
    {
        string key = TROPHIES_COLLECT + CurrentLevel;

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
            PlayerPrefs.SetInt(key,TotalDiamondCollected);
        }
    }
    private static void SaveBubbleTrophies()
    {
        string key = TROPHIES_BUBBLE_COLLECT + CurrentLevel;

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
            PlayerPrefs.SetInt(key,TotalBubbleCollected);
        }
    }
}
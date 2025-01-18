using UnityEngine;

public static class DataManager
{
    public const string TROPHIES_COLLECT = "TROPHIES_COLLECT_";
    public const string TIME_COMPLETE = "TIME_COMPLETE_";
    public static int CurrentLevel = 0;
    public static int TotalCollected = 0;
    public static int TotalTime = 0;

    public static void Save()
    {
        SaveTrophies();
        SaveTimeComplete();
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

            if (TotalCollected > currentValue)
            {
                PlayerPrefs.SetInt(key, TotalCollected);
            }
        }
        else
        {
            PlayerPrefs.SetInt(key,TotalCollected);
        }
    }
}
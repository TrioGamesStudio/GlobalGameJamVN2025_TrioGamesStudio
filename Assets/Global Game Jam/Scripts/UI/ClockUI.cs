using TMPro;
using UnityEngine;

public class ClockUI : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    private void Awake()
    {
        timerText.text = FormatTime(0);
    }

    public void UpdateTimer(int timer)
    {
        timerText.text = FormatTime(timer);
    }
    public static string FormatTime(int totalSeconds)
    { 
        int minutes = totalSeconds / 60; 
        int seconds = totalSeconds % 60;
        return string.Format("{0}'{1}s", minutes, seconds);
    }
}
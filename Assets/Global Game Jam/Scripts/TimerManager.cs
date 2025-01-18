using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private int timer = 0;

    public Action<int> OnTimerChanged;

    [SerializeField] private bool canTimer = false;
    private YieldInstruction waitForOneSecond;

    private void Awake()
    {
        waitForOneSecond = new WaitForSeconds(1);
    }

    public void OnStartTimer()
    {
        canTimer = true;
        StartCoroutine(StartTimer());
    }

    public void OnStopTimer()
    {
        canTimer = false;
        StartCoroutine(StartTimer());
    }
    
    private void OnDestroy()
    {
        StopCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        while (canTimer)
        {
            timer++;
            OnTimerChanged?.Invoke(timer);
            yield return waitForOneSecond;
        }
    }
    
}

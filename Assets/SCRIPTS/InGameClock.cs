using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 


public class InGameClock : MonoBehaviour

{
    public TextMeshProUGUI timerText; // Assign a UI Text element in the Inspector
    private float elapsedTime = 0f;
    private bool isRunning = true;

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimer();
        }
    }

    void UpdateTimer()
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(elapsedTime);
        timerText.text = string.Format("{0:D2}:{1:D2}", timeSpan.Hours, timeSpan.Minutes);
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void ResetTimer()
    {
        elapsedTime = 0f;
        UpdateTimer();
    }
}

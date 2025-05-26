using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MenuClock : MonoBehaviour
{

    public TextMeshProUGUI clockText; // Assign a UI Text element in the Inspector
    //this is a clock that stays up to date with the current time irl, wonder if i can make an ingame clock the same way i made the coin collection script..
    void Update()
    {
        UpdateClock();
    }

    void UpdateClock()
    {
        DateTime now = DateTime.Now;
        clockText.text = now.ToString("HH.mm"); // 24-hour format add :ss" for seconds
    } //i litterally editied this ":" to make  it more aplicable to made up money 
}



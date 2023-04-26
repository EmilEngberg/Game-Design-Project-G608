using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class countdownTimer : MonoBehaviour
{
    bool timerActive = true;
    bool victimsSaved = false;
    float currentTime;
    public int startTime;
    public TextMeshProUGUI countdownText;
    public EndScreenManager endScreenManager;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime * 60; //The current time is stored as seconds

    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive == true)
        {
            currentTime = currentTime - Time.deltaTime; //If the timer is active, each frame decreases the current time,
                                                        //with the amount of milliseconds that has passed since the last update
            if (currentTime <= 0) //If the time gets to 0...
            {
                timerActive = false; //timerActive is set to false
                Start(); //The Start() function is loaded again, causing a the timer to reset
                endScreenManager.SetGameOver(); //the SetGameOver from EndScreenManager.cs starts, showing the end screen               
                Debug.Log("Game has ended!");
            }
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime); //Stores the current time as seconds, makes it easy to convert to minutes
        countdownText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString(); //Utilizes line 38 to display the time in minutes and seconds
        
        if(victimsSaved == false)
        {   
            //Checks if there is any victims left to save
            if(GameObject.FindGameObjectWithTag("Victim") == null)
            {
                timerActive = false;
                endScreenManager.SetYouWin();
                Debug.Log("I WIN");
                victimsSaved = true;
            }
        }
    }

    public void StartTimer()
    {
        timerActive = true;
    }

    public void StopTimer()
    {
        timerActive = false;
    }
}

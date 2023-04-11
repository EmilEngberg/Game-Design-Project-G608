using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class countdownTimer : MonoBehaviour
{
    bool timerActive = true;
    float currentTime;
    public int startTime;
    public TextMeshProUGUI countdownText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime * 60;

    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive == true)
        {
            currentTime = currentTime - Time.deltaTime;
            if (currentTime <= 0)
            {
                timerActive = false;
                Start();
                //End screen kode skal være her, så når timeren slutter, så kommer der en end screen of sorts
                Debug.Log("Game has ended!");
            }
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        countdownText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
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

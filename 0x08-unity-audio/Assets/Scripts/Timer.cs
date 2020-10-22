﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public Text finalText;
    private float msecondsCount;
    private float secondsCount;
    private int minuteCount;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimerUI();  
    }
     public void UpdateTimerUI(){
         //set timer UI
         msecondsCount += Time.deltaTime * 100;
         if (secondsCount < 10)
            timerText.text = minuteCount + ":0" + (int)secondsCount + "." + (int)msecondsCount;
         else
            timerText.text = minuteCount + ":" + (int)secondsCount + "." + (int)msecondsCount;
    
         if(msecondsCount >= 60)
         {
             secondsCount++;
             msecondsCount = 0;
         }
         else if(secondsCount >= 60)
         {
             minuteCount++;
             secondsCount = 0;
         }    
}

public void Win()
{
    timerText.enabled = false;
    if (secondsCount < 10)
        finalText.text = minuteCount + ":0" + (int)secondsCount + "." + (int)msecondsCount;
    else
        finalText.text = minuteCount + ":" + (int)secondsCount + "." + (int)msecondsCount;
}

void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Win")
            Win();
            
    }
}

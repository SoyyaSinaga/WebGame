using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timerMid : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    private bool isTimerRunning = false;
    public GameObject gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = seconds.ToString();
      
        if (isTimerRunning)
        {
            remainingTime -= Time.deltaTime;

            if (remainingTime <= 0)
            {
                remainingTime = 0;
                StopTimer();
            }
        }

    }

    public void TimerResetEZ()
    {
      remainingTime = 5.99f;        
        StartTimer();
    }

    public void TimerResetMid()
    {
        remainingTime = 3.99f;
        StartTimer();
    }

    public void StopTimer()
    {
        isTimerRunning = false;
        gamemanager.GetComponent<rpsMid> ().NoAction();
    }

    // Call this to start the timer
    public void StartTimer()
    {
        isTimerRunning = true;
    }

}
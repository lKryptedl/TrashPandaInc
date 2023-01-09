using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerUI : MonoBehaviour
{
   
    public float amountoftime; //5 minutes
    public float maxAmountOfTime;
    public TextMeshProUGUI timeUI;
    public float minutes;
    public float seconds;
    public float timepassed;
    private GameObject ScoreCounter;
    private void Awake()
    {
        amountoftime = maxAmountOfTime;
    }

    void Update()
    {
        if (amountoftime > timepassed)
        {
            amountoftime -= Time.deltaTime;
        }
        // DisplayTimer(amountoftime);
        seconds = Mathf.FloorToInt(amountoftime % 60);
        minutes = Mathf.FloorToInt(amountoftime / 60);
        timeUI.text = string.Format("{0:00} : {1:00}", minutes, seconds);
        if (amountoftime <= timepassed)
        {
            ScoreCounter = GameObject.Find("Score Counter");
            ScoreCounter.GetComponent<Score>().finalScore();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static int PlayerScore = 0;
    public TMP_Text text;
    public static int RobotsLeft = 0;
    public static int rubbishLeft = 0;

    void Update()
    {
        text.text = PlayerScore.ToString(); 
    }

    public void finalScore()
    {
        PlayerScore -= ((RobotsLeft * 500) + (rubbishLeft * 50));
    }

    public void resetScore()
    {
        PlayerScore = 0;
        RobotsLeft = 0;
        rubbishLeft = 0;
    }
}

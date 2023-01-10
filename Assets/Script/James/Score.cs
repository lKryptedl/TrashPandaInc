using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static int PlayerScore = 0;
    public TMP_Text text;
    public static int RobotsLeft = 0;
    public static int rubbishLeft = 0;
    public void Start()
    {
        Score.PlayerScore = 0;
        Score.RobotsLeft = 0;
        Score.rubbishLeft = 0;
    }
    void Update()
    {
        text.text = PlayerScore.ToString(); 
    }

    public void finalScore()
    {
        PlayerScore -= (rubbishLeft * 50);
        SceneManager.LoadScene("FinalScore");
        Time.timeScale = 1;
    }
}

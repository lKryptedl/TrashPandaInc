using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    public Button restart;
    public void Start()
    {
        restart.onClick.AddListener(Reset);
    }

    public void Reset()
    {
        Score.PlayerScore = 0;
        Score.RobotsLeft = 0;
        Score.rubbishLeft = 0;
        LoadingScript.leveltoload = ("ReactorBridgeBlockout");
        SceneManager.LoadScene("Loading");
    }
}

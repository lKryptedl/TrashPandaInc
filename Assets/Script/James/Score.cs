using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int PlayerScore = 0;
    public Text text;

    void Update()
    {
        text.text = PlayerScore.ToString(); 
    }
}

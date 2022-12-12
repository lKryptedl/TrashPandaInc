using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static int PlayerScore = 0;
    public TMP_Text text;

    void Update()
    {
        text.text = PlayerScore.ToString(); 
    }
}

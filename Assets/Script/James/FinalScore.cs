using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalScore : MonoBehaviour
{
    public TMP_Text text;
    public GameObject star1, star2, star3;
    public int onestar = 5000, twostar = 10000, threestar = 15000;

    void Start()
    {
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
        text.text = Score.PlayerScore.ToString();
        if (Score.PlayerScore >= threestar)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        }
        else if (Score.PlayerScore >= twostar)
        {
            star1.SetActive(true);
            star2.SetActive(true);
        }
        else if (Score.PlayerScore >= onestar)
        {
            star1.SetActive(true);
        }
    }
}

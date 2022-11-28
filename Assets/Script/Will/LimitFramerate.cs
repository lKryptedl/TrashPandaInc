using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitFramerate : MonoBehaviour
{
    public int TargetFramerate = 60;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = TargetFramerate;
    }

    private void Update()
    {
        if(Application.targetFrameRate != TargetFramerate)
        {
            Application.targetFrameRate = TargetFramerate;
        }
    }
}

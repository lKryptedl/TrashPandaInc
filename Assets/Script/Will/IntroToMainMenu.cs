using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class IntroToMainMenu : MonoBehaviour
{
    public float TimeToSwitch;
    void Start()
    {
        StartCoroutine(nameof(SwitchToMenu));
    }
    IEnumerator SwitchToMenu()
    {
        yield return new WaitForSecondsRealtime(TimeToSwitch);
        SceneManager.LoadScene("Main Menu");
        print("Change Scene");
    }
    private void Update()
    {
        if (Gamepad.current.aButton.wasPressedThisFrame)
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class QuitToMenu : MonoBehaviour
{
    void Update()
    {
        if (Gamepad.current.bButton.wasPressedThisFrame)
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}

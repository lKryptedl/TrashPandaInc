using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public GameObject Pause, SettingsMenu;
    public new AudioMixer audio;
    public AimControl MaxSpeed;
    public Button settingsButton, backButton;
    public void OnResume()
    {
        PlayerController.Pause = true;
        Pause.SetActive(false);
    }
    public void OnSettings()
    {
        Pause.SetActive(false);
        SettingsMenu.SetActive(true);
        backButton.Select();
    }
    public void OnMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void OnBack()
    {
        SettingsMenu.SetActive(false);
        Pause.SetActive(true);
        settingsButton.Select();
    }
    public void Volume(float vol)
    {
        audio.SetFloat("volume", vol);
    }
    public void SensitivityX(float SensX)
    {
        MaxSpeed.xAxis.m_MaxSpeed = SensX;
    }
    public void SensitivityY(float SensY)
    {
        MaxSpeed.yAxis.m_MaxSpeed = SensY;
    }

}

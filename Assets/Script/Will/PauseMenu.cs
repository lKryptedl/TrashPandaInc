using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject SettingsMenu;
    public GameObject Pause;
    [SerializeField] Slider volumeSlider, SensXSlider, SensYSlider;
    public AimControl MaxSpeed;
    public Button settingsButton, backButton, ControlsButton;
    private Button SettingsButton;
    private Scene currentScene;
    public GameObject controlsImage;

    private void Start()
    {
        //volumeSlider.value = volumeSlider.value;
        currentScene = SceneManager.GetActiveScene();
        if(currentScene.name == "Main Menu")
        {
            Time.timeScale = 1;
        }
        LoadVol();
        LoadSensX();
        LoadSensY();
    }
    private void Update()
    {
        if (currentScene.name == "ReactorBridgeBlockout" || currentScene.name == "Tutorial")
        {
            if (SettingsMenu.activeInHierarchy)
            {
                if (Gamepad.current.bButton.wasPressedThisFrame)
                {
                    SettingsMenu.SetActive(false);
                    Pause.SetActive(true);
                    settingsButton.Select();
                }
            }
        }
        else if (currentScene.name == "Main Menu")
        {
            if (SettingsMenu.activeInHierarchy)
            {
                if (Gamepad.current.bButton.wasPressedThisFrame)
                {
                    SettingsMenu.SetActive(false);
                    settingsButton.Select();
                }
            }
        }
        if (controlsImage.activeInHierarchy)
        {
            if (Gamepad.current.bButton.wasPressedThisFrame)
            {
                controlsImage.SetActive(false);
                PlayerController.Pause = false;
                Time.timeScale = 0;
                Pause.SetActive(true);
                ControlsButton.Select();
            }
        }
    }
    public void OnResume()
    {
        PlayerController.Pause = true;
        Pause.SetActive(false);
    }
    public void OnMenuBack()
    {
        settingsButton.Select();
    }
    public void OnSettings()
    {
        if (currentScene.name != "Main Menu")
        {
            Pause.SetActive(false);
        }
        SettingsMenu.SetActive(true);
        backButton.Select();
    }
    public void OnMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }
    public void OnBack()
    {
        SettingsMenu.SetActive(false);
        Pause.SetActive(true);
        settingsButton.Select();
    }
    public void Volume()
    {
        AudioListener.volume = volumeSlider.value;
        SaveVol();
    }
    public void SensitivityX()
    {
        MaxSpeed.xAxis.m_MaxSpeed = SensXSlider.value;
        SaveSensX();

    }
    public void SensitivityY()
    {
        MaxSpeed.yAxis.m_MaxSpeed = SensYSlider.value;
        SaveSensY();
    }
    private void LoadVol()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volume");
        PlayerPrefs.Save();
    }
    private void SaveVol()
    {
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
        PlayerPrefs.Save();
    }
    private void LoadSensX()
    {
        SensXSlider.value = PlayerPrefs.GetFloat("SensX");
    }
    private void SaveSensX()
    {
        PlayerPrefs.SetFloat("SensX", SensXSlider.value);
        PlayerPrefs.Save();
    }
    private void LoadSensY()
    {
        SensYSlider.value = PlayerPrefs.GetFloat("SensY");
    }
    private void SaveSensY()
    {
        PlayerPrefs.SetFloat("SensY", SensYSlider.value);
        PlayerPrefs.Save();
    }

}

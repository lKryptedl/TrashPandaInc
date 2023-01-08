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
    [SerializeField] Slider volumeSlider, SensXSlider, SensYSlider;
    public AimControl MaxSpeed;
    public Button settingsButton, backButton;
    private void Start()
    {
        LoadVol();
        LoadSensX();
        LoadSensY();
    }
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
    }
    private void SaveVol()
    {
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
    }
    private void LoadSensX()
    {
        SensXSlider.value = PlayerPrefs.GetFloat("SensX");
    }
    private void SaveSensX()
    {
        PlayerPrefs.SetFloat("SensX", SensXSlider.value);
    }
    private void LoadSensY()
    {
        SensYSlider.value = PlayerPrefs.GetFloat("SensY");
    }
    private void SaveSensY()
    {
        PlayerPrefs.SetFloat("SensY", SensYSlider.value);
    }

}

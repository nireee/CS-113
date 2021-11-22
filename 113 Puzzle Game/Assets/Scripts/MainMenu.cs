using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject SettingsPanel;
    public GameObject MenuUI;
    public UnityEngine.UI.Toggle toggle;
    public UnityEngine.UI.Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        float volume = PlayerPrefs.GetFloat("volume", 1);
        bool mute = PlayerPrefs.GetString("mute", "no") == "no" ? false : true;
        VolumeSlider(volume);
        slider.value = volume;
        MuteToggle(mute);
        toggle.isOn = mute;
    }

    public void StartGameButton()
    {
        SceneManager.LoadScene(1);
    }

    public void SettingButton()
    {
        SettingsPanel.SetActive(!SettingsPanel.activeSelf);
        MenuUI.SetActive(false);

    }

    public void VolumeSlider(float volume)
    {
        AudioHandler.StaticAudioHandler.SetVolume(volume);
        PlayerPrefs.SetFloat("volume", volume);
    }

    public void MuteToggle(bool state)
    {
        AudioHandler.StaticAudioHandler.Mute(state);
        if (state)
        {
            PlayerPrefs.GetString("mute", "yes");
        }
        else
        {
            PlayerPrefs.GetString("mute", "no");
        }
    }

    public void PlayClickSound()
    {
        AudioHandler.StaticAudioHandler.StartClickSound("ClickSound");
    }

    public void BackToMainMenu()
    {
        SettingsPanel.SetActive(!SettingsPanel.activeSelf);
        MenuUI.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

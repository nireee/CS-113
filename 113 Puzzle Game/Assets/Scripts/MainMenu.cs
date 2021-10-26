using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject SettingsPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGameButton()
    {
        SceneManager.LoadScene(1);
    }

    public void SettingButton()
    {
        SettingsPanel.SetActive(!SettingsPanel.activeSelf);

    }

    //public void VolumeSlider(float volume)
    //{

    //}

    //public void MuteToggle(bool value)
    //{
       
    //}
}

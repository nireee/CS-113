using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour
{
    public bool PauseMenuOpen;
    public GameObject PausePanel;
    // Start is called before the first frame update
    void Start()
    {
        PausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PausePanel.SetActive(true);
        }
    }

    public void ResumeGame()
    {
        PausePanel.SetActive(false);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
        PausePanel.SetActive(false);
    }

    public void RestartGame()
    {
        PausePanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

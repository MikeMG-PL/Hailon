using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject panel, cornerPauseButton, resumeButton, settingsButton, quitButton;

    void Start()
    {
        Time.timeScale = 1;
        ShowGame();
    }

    void Awake()
    {
        ShowGame();    
    }

    public void ShowPauseMenu()
    {
        panel.SetActive(true);
        cornerPauseButton.SetActive(false);
        resumeButton.SetActive(true);
        settingsButton.SetActive(true);
        quitButton.SetActive(true);
    }

    public void ShowGame()
    {
        panel.SetActive(false);
        cornerPauseButton.SetActive(true);
        resumeButton.SetActive(false);
        settingsButton.SetActive(false);
        quitButton.SetActive(false);
    }
}

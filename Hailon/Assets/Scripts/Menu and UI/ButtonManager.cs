using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Notification = Notifications.Notification;
using MovementAllowed = InputManager.MovementAllowed;

public class ButtonManager : MonoBehaviour
{
    MenuManager menuManager;

    void Start()
    {
        menuManager = GetComponent<MenuManager>();
    }

    public void Play()
    {
        menuManager.LevelMenu();
        SoundManager.soundManager.Click();
    }

    public void Customize()
    {
        SoundManager.soundManager.Click();
        return;
    }

    public void Settings()
    {
        SoundManager.soundManager.Click();
        return;
    }

    public void Quit()
    {
        SoundManager.soundManager.Click();
        Application.Quit();
    }

    public void Pause()
    {
        SoundManager.soundManager.Click();
        switch (Notifications.IsPaused())
        {
            case true:
                Notifications.Notify(Notification.GamePlaying);
                InputManager.AllowMovement(MovementAllowed.Yes);
                GetComponent<PauseMenu>().ShowGame();
                Time.timeScale = 1;

                break;

            case false:
                InputManager.AllowMovement(MovementAllowed.No);
                Notifications.Notify(Notification.GamePaused);
                GetComponent<PauseMenu>().ShowPauseMenu();
                Time.timeScale = 0;
                
                break;
        }
    }

    public void NextLevel()
    {
        GameManager.gameManager.LoadScene(SceneManager.GetSceneAt(SceneManager.GetActiveScene().buildIndex + 1).name, SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        GameManager.gameManager.LoadScene("Menu", SceneManager.GetActiveScene().name);
    }

    ////////////////////////

    public void LoadLevel(int levelNumber)
    {
        GameManager.gameManager.LoadScene(levelNumber.ToString(), SceneManager.GetActiveScene().name);
    }
}

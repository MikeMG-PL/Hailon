﻿using System.Collections;
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
    }

    public void Customize()
    {
        return;
    }

    public void Settings()
    {
        return;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Pause()
    {
        switch (Notifications.IsPaused())
        {
            case true:
                Notifications.Notify(Notification.GamePlaying);
                InputManager.AllowMovement(MovementAllowed.Yes);
                Time.timeScale = 1;

                break;

            case false:
                InputManager.AllowMovement(MovementAllowed.No);
                Notifications.Notify(Notification.GamePaused);
                Time.timeScale = 0;
                break;
        }
    }

    ////////////////////////

    public void LoadLevel(int levelNumber)
    {
        SceneManager.LoadSceneAsync(levelNumber.ToString());
    }
}

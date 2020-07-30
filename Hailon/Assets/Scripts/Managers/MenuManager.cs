using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public enum MenuState { MainMenu, LevelMenu, Customize, Settings };
    public MenuState state;

    public GameObject mainMenu, levelMenu, customize, settings;

    void Awake()
    {
        Time.timeScale = 1;
        MainMenu();
    }

    public void MainMenu()
    {
        mainMenu.SetActive(true);
        levelMenu.SetActive(false);
        customize.SetActive(false);
        settings.SetActive(false);
    }

    public void LevelMenu()
    {
        SoundManager.soundManager.Click();
        mainMenu.SetActive(false);
        levelMenu.SetActive(true);
        customize.SetActive(false);
        settings.SetActive(false);
    }

    public void Customize()
    {
        SoundManager.soundManager.Click();
        mainMenu.SetActive(false);
        levelMenu.SetActive(false);
        customize.SetActive(true);
        settings.SetActive(false);
    }

    public void Settings()
    {
        SoundManager.soundManager.Click();
        mainMenu.SetActive(false);
        levelMenu.SetActive(false);
        customize.SetActive(false);
        settings.SetActive(true);
    }
}

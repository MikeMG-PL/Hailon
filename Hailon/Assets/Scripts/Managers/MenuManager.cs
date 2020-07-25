using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public enum MenuState { MainMenu, LevelMenu, Customize, Settings };
    public MenuState state;

    public GameObject mainMenu, levelMenu, customize, settings;

    void Start()
    {
        Time.timeScale = 1;
        MainMenu();    
    }

    void OnLevelWasLoaded(int level)
    {
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
        mainMenu.SetActive(false);
        levelMenu.SetActive(true);
        customize.SetActive(false);
        settings.SetActive(false);
    }

    public void Customize()
    {
        mainMenu.SetActive(false);
        levelMenu.SetActive(false);
        customize.SetActive(true);
        settings.SetActive(false);
    }

    public void Settings()
    {
        mainMenu.SetActive(false);
        levelMenu.SetActive(false);
        customize.SetActive(false);
        settings.SetActive(true);
    }
}

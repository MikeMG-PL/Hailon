using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public enum MenuState { MainMenu, LevelMenu, Customize, Settings };
    public MenuState state;

    public Transform levelsButtonsParent;
    int currentLevel = 1;
    public List<GameObject> levels = new List<GameObject>();

    public GameObject mainMenu, levelMenu, customize, settings;

    void Awake()
    {
        Time.timeScale = 1;
        MainMenu();
        ManageLevelMenu();
    }

    void ManageLevelMenu()
    {
        currentLevel = GameManager.gameManager.GetComponent<PlayerData>().level;

        foreach (Transform lvl in levelsButtonsParent)
        {
            levels.Add(lvl.gameObject);
        }

        for (int i = 1; i <= currentLevel; i++)
        {
            levels[i - 1].GetComponent<Button>().interactable = true;
        }

    }

    public void MainMenu()
    {
        SoundManager.soundManager.Click();
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

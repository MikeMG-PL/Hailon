﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitManager : MonoBehaviour
{
    public ButtonManager buttonManager;

    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Menu" && SceneManager.GetActiveScene().name != "Loading")
        {       
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                //GameManager.gameManager.LoadScene("Menu", SceneManager.GetActiveScene().name);
                buttonManager.Pause();
            }
        }

        if (SceneManager.GetActiveScene().name == "Menu" && Input.GetKeyDown(KeyCode.Escape))
            Application.Quit(); // dodać do notifications to, że gracz jest w LevelMenu i żeby przycisk escape także cofał do menu a nie zamykał apkę!
    }
}

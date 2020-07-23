using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadSceneAsync("Game");
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
}

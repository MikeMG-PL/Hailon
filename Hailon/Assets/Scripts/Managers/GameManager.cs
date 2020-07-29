using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    bool gameStart;

    private void Awake()
    {
        if (!gameStart)
        {
            gameManager = this;
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
            gameStart = true;
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        if (scene.name == "NeverUnload") return;

        SceneManager.SetActiveScene(scene);
    }

    public void LoadScene(string sceneToLoad, string currentScene)
    {
        SceneManager.UnloadSceneAsync(currentScene);
        SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);
    }
}

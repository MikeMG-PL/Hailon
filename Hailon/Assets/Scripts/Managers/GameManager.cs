using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    bool gameStart;

    void Awake()
    {
        if (!gameStart)
        {
            gameManager = this;
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
            gameStart = true;

            LoadData();
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void LoadScene(string sceneToLoad, string currentScene)
    {
        SceneManager.UnloadSceneAsync(currentScene);
        SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        if (scene.name == "NeverUnload") return;

        SceneManager.SetActiveScene(scene);
    }

    void LoadData()
    {
        SaveData data = SaveManager.LoadProgress();
        if (data == null) return;
        GetComponent<PlayerData>().level = data.level;
    }

    void OnApplicationQuit()
    {
        SaveManager.SaveProgress(GetComponent<PlayerData>());
    }
}

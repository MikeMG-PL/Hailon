using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathRestart : MonoBehaviour
{
    float timer;

    private void Awake()
    {
        timer = 0;
    }

    void Update()
    {
        if (Notifications.IsPlayerKilled() && SceneManager.GetActiveScene().name != "Menu")
        {
            Restart();
        }
    }

    void Restart()
    {
        timer += Time.deltaTime;

        if (timer >= 2)
        {
            GameManager.gameManager.LoadScene(SceneManager.GetActiveScene().name, SceneManager.GetActiveScene().name);
        }
    }
}

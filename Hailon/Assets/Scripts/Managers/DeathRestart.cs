using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathRestart : MonoBehaviour
{
    float timer;

    void Update()
    {
        if (Notifications.IsPlayerKilled())
        {
            Restart();
        }
    }

    void Restart()
    {
        timer += Time.deltaTime;

        if (timer >= 2)
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        }
    }
}

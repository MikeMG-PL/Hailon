using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [HideInInspector]
    public LevelData levelData;
    public GameObject levelFinishedUI;
    public Objective objective;

    private void Start()
    {
        if (objective == null) Debug.LogError("You need to assign Finish object (object with objective script)");

        levelData = GetComponent<LevelData>();
        levelData.index = Convert.ToInt32(SceneManager.GetActiveScene().name);
        objective.ObjectiveReached += OnObjectiveReached;
    }

    private void OnObjectiveReached(object sender, System.EventArgs e)
    {
        levelData.finished = true;
        levelFinishedUI.SetActive(true);

        PlayerData playerData = GameManager.gameManager.GetComponent<PlayerData>();
        if (playerData.level < levelData.index) playerData.level = levelData.index;
        SaveManager.SaveProgress(playerData);
    }
}

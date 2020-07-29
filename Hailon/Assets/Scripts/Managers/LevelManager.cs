using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public int currentLevel = 1;
    public List<GameObject> levels = new List<GameObject>();

    private void Start()
    {
        currentLevel = GameManager.gameManager.GetComponent<PlayerData>().level;

        foreach (Transform lvl in transform)
        {
            levels.Add(lvl.gameObject);
        }

        for (int i = 1; i <= currentLevel; i++)
        {
            levels[i - 1].GetComponent<Button>().interactable = true;
        }
    }
}

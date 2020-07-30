using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int level;
    public int money;

    public SaveData(PlayerData player)
    {
        level = player.level;
    }
}

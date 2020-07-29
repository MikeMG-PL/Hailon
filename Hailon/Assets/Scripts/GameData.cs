using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    private int level;
    private int money;

    public GameData(PlayerData player)
    {
        level = player.level;
    }
}

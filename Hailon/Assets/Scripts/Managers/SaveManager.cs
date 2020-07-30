using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static void SaveProgress(PlayerData player)
    {
        string path = Path.Combine(Application.persistentDataPath, "data.dat");

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);
        SaveData data = new SaveData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveData LoadProgress()
    {
        string path = Path.Combine(Application.persistentDataPath, "data.dat");
        Debug.Log(path);
        if (!File.Exists(path))
        {
            Debug.LogWarning("Saved data file doesn't exist.");
            return null;
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);
        SaveData data = (SaveData)formatter.Deserialize(stream);

        stream.Close();
        return data;
    }
}

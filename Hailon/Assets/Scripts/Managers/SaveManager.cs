using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static void SaveProgress()
    {
        string path = Path.Combine(Application.persistentDataPath, "data.dat");

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);
        GameData data = new GameData();

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData LoadProgress()
    {
        string path = Path.Combine(Application.persistentDataPath, "data.dat");

        if (!File.Exists(path))
        {
            Debug.LogError("Saved data file doesn't exist.");
            return null;
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);
        GameData data = (GameData)formatter.Deserialize(stream);

        stream.Close();
        return data;
    }
}

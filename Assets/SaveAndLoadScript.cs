using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;

public static class SaveAndLoadScript
{
    public static void SaveGame(GameProgress data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playerPrefs.dat";
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameProgress LoadGame()
    {
        string path = Application.persistentDataPath + "/playerPrefs.dat";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            GameProgress data = (GameProgress)formatter.Deserialize(stream);
            stream.Close();
            return data;
        }
        else
        {
            return null;
        }
    }

    public static void ResetGameData()
    {
        string path = Application.persistentDataPath + "/playerPrefs.dat";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
}

[System.Serializable]
public class GameProgress
{
    public int playerProgress;
}

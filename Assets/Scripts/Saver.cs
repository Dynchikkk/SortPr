using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Saver : MonoBehaviour
{
    [HideInInspector]
    public List<Par> ParsToSave = new List<Par>();

    private void Awake()
    {
        LoadGame();
    }

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
          + "/MySaveData.dat");
        SavedData data = new SavedData();
        data.savedPars.Clear();

        foreach (var item in ParsToSave)
        {
            data.savedPars.Add(item);
        }

        bf.Serialize(file, data);
        file.Close();

        ParsToSave.Clear();

        Debug.Log("Game data saved!");
    }

    public void LoadGame()
    {
        ParsToSave.Clear();

        if (File.Exists(Application.persistentDataPath
          + "/MySaveData.dat"))
        {
            print(Application.persistentDataPath
          + "/MySaveData.dat");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =
              File.Open(Application.persistentDataPath
              + "/MySaveData.dat", FileMode.Open);
            SavedData data = (SavedData)bf.Deserialize(file);
            file.Close();

            foreach (var item in data.savedPars)
            {
                ParsToSave.Add(item);
            }

            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }
}

[Serializable]
public class SavedData
{
    public List<Par> savedPars = new List<Par>();
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Saver : MonoBehaviour
{
    [HideInInspector]
    public List<Line> LineListToSave = new List<Line>();

    private void Awake()
    {
        //LoadGame();
    }

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
          + "/MySaveData.dat");
        SavedData data = new SavedData();

        foreach (var item in LineListToSave)
        {
            data.savedLineList.Add(item);
        }

        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved!");
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath
          + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =
              File.Open(Application.persistentDataPath
              + "/MySaveData.dat", FileMode.Open);
            SavedData data = (SavedData)bf.Deserialize(file);
            file.Close();
            foreach (var item in data.savedLineList)
            {
                LineListToSave.Add(item);
            }
            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }
}

[System.Serializable]
public class SavedData
{
    public List<Line> savedLineList;
}

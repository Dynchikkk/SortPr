using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class Saver : MonoBehaviour
{
    [HideInInspector]
    public List<LineContent> lineListToSave = new List<LineContent>();

    private void Awake()
    {
        //LoadGame();
        LoadGame();
    }

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
          + "/MySaveData.dat");
        SavedData data = new SavedData();
        data.savedLineList.Clear();

        foreach (var item in lineListToSave)
        {
            data.savedLineList.Add(item);
        }

        bf.Serialize(file, data);
        file.Close();

        lineListToSave.Clear();

        Debug.Log("Game data saved!");
    }
    public void LoadGame()
    {
        lineListToSave.Clear();

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
                lineListToSave.Add(item);
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
    public List<LineContent> savedLineList = new List<LineContent>();
}
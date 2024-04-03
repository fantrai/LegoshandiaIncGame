using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

/// <summary>
/// управление сохранениями в игре
/// </summary>
public static class SaveManager
{
    static SaveManager()
    {
        Start();
    }

    static void Start()
    {
        if (File.Exists(pathToSave))
        {
            save = JsonConvert.DeserializeObject<Save>(File.ReadAllText(pathToSave));
        }
        else
        {
            save = new Save();
            save.punchases = new Dictionary<string, uint>();
            save.achivements = new Dictionary<string, uint>();
        }
    }

    public static Save save;

    static string pathToSave = Application.persistentDataPath + "Save";

    public static void SaveData()
    {
        File.WriteAllText(pathToSave, JsonConvert.SerializeObject(save));
    }

   public static void RemoveSave()
    {
        if (File.Exists(pathToSave))
        {
            File.Delete(pathToSave);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Start();
    }
}
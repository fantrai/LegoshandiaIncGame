using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// управление сохранениями в игре
/// </summary>
public static class SaveManager
{
    static SaveManager()
    {
        if (File.Exists(pathToSave))
        {
            save = JsonUtility.FromJson<Save>(File.ReadAllText(pathToSave));
        }
        else
        {
            save = new Save();
        }
    }

    public static Save save;

    static string pathToSave = Application.persistentDataPath + "Save";

    public static void SaveData()
    {
        File.WriteAllText(pathToSave, JsonUtility.ToJson(save));
    }
}
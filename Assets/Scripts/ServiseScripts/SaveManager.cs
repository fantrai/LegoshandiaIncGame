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
            save.flies = new(save.fliesForByte);
            save.fliesForFly = new(save.fliesForFlyForByte);
            save.passivFliesPerSecond = new(save.passivFliesPerSecondForBytes);
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
        save.fliesForByte = save.flies.ToByteArray();
        save.fliesForFlyForByte = save.fliesForFly.ToByteArray();
        save.passivFliesPerSecondForBytes = save.passivFliesPerSecond.ToByteArray();
        File.WriteAllText(pathToSave, JsonUtility.ToJson(save));
    }

    public static void RemoveSave()
    {
        if (File.Exists(pathToSave))
        {
            File.Delete(pathToSave);
            save = new Save();
        }
    }
}
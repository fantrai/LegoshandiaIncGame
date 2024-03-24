using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Управление вкладкой настроек
/// </summary>
public class Settings : MonoBehaviour
{
    public void VolumeButton()
    {
        AudioListener.pause = !AudioListener.pause;
        SaveManager.save.music = AudioListener.pause;
    }

    public void RemoveSaveFile()
    {
        SaveManager.RemoveSave();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

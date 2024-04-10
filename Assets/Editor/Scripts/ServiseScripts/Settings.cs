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
    }

    public void TelegramButt()
    {
        Application.OpenURL("https://t.me/legoshandia");
    }

    public void DiscordButt()
    {
        Application.OpenURL("https://discord.gg/wFN2dQcJH4");
    }
}

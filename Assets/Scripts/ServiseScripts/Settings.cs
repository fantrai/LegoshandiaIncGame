using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}

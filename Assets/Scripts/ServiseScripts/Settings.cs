using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���������� �������� ��������
/// </summary>
public class Settings : MonoBehaviour
{
    public void VolumeButton()
    {
        AudioListener.pause = !AudioListener.pause;
        SaveManager.save.music = AudioListener.pause;
    }
}

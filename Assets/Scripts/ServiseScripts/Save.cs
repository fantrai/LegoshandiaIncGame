using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Newtonsoft.Json;

/// <summary>
/// файл сохранения
/// </summary>
public class Save
{
    public BigInteger flies = 0;
    public uint fliesPerSecond = 0;
    public uint fliesPerClick = 1;
    public BigInteger fliesForFly = 1;
    public BigInteger passivFliesPerSecond = 0;


    public float waitFlies = 2f;

    public uint goldFlies = 0;
    public uint goldFliesForGoldFly = 1;

    public float speedEating = 1f;

    public uint coolness = 0;
    public uint LvlCoolness = 1;
    public uint coolnessBeforeNextLvl = 100;

    public bool music = true;

    public Dictionary<string, uint> punchases;
    public Dictionary<string, uint> achivements;

    //для достижений
    public BigInteger takeFlies = 0;
    public uint takeGoldFlies = 0;
    public BigInteger clickCount = 0;
    public uint openFrogs = 0;
    public uint openColors = 0;
    public uint openLocations = 0;
    public DateTime timeInGame = new DateTime(2024, 03, 31, 0, 0, 0);
}
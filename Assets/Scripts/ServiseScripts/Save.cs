using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

/// <summary>
/// файл сохранения
/// </summary>
[Serializable]
public class Save
{
    public BigInteger flies = 0;
    public uint fliesPerSecond = 0;
    public uint fliesPerClick = 1;
    public BigInteger fliesForFly = 1;

    public float waitFlies = 2f;

    public uint goldFlies = 0;
    public uint goldFliesForGoldFly = 1;

    public float speedEating = 1f;

    public uint coolness = 0;
    public uint LvlCoolness = 1;
    public uint coolnessBeforeNextLvl = 100;

    public bool music = true;

    public Dictionary<string, uint> punchases = new Dictionary<string, uint>();
}
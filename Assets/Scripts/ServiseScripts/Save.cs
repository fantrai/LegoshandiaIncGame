using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;

/// <summary>
/// файл сохранения
/// </summary>
[Serializable]
public class Save
{
    [DoNotSerialize] public BigInteger flies = 0;
    public byte[] fliesForByte = new BigInteger(0).ToByteArray();
    public uint fliesPerSecond = 0;
    public uint fliesPerClick = 1;
    [DoNotSerialize] public BigInteger fliesForFly = 1;
    public byte[] fliesForFlyForByte = new BigInteger(1).ToByteArray();
    [DoNotSerialize] public BigInteger passivFliesPerSecond = 1;
    public byte[] passivFliesPerSecondForBytes = new BigInteger(1).ToByteArray();


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
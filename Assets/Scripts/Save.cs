using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

[Serializable]
public class Save
{
    public BigInteger flies = 0;
    public uint fliesPerSecond = 200;
    public uint fliesPerClick = 0;
    public BigInteger fliesForFly = 2;

    public float waitFlies = 2f;

    public uint goldFlies = 0;
    public uint goldFliesForGoldFly = 1;

    public float speedFliesPerSecond = 100;

    public uint coolness = 0;
    public uint LvlCoolness = 1;
    public uint coolnessBeforeNextLvl = 100;

    public Dictionary<string, uint> punchases;
}
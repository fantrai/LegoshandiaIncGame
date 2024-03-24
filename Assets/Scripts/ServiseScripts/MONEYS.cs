using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

/// <summary>
/// именование модификаторов к мухам
/// </summary>
public enum ModsForMoney
{
    flies,
    k,
    m,
    b,
}

/// <summary>
/// управление большими числами мух
/// </summary>
public static class MONEYS
{
    static Dictionary<ModsForMoney, string> VALS = new Dictionary<ModsForMoney, string>() 
    {
        { ModsForMoney.flies, "" },
        { ModsForMoney.k, "k" },
        { ModsForMoney.m, "m" },
        { ModsForMoney.b, "b" },
    };

    public static ModsForMoney ConvertToMod(BigInteger val, out BigInteger retVal, out BigInteger remains)
    {
        retVal = val;
        int countDiv = 0;
        remains = 0;
        while (retVal > 1000)
        {
            retVal = BigInteger.DivRem(retVal, 1000, out remains);
            countDiv++;
        }
        return (ModsForMoney)countDiv;
    }

    public static BigInteger ConvertToBigInt(BigInteger val, ModsForMoney mod, BigInteger remains) 
    {
        BigInteger resurt = val;

        for (int i = 0; i < ((int)mod); i++)
        {
            resurt *= 1000;
            if (i == 0) resurt += remains;
        }
        return resurt;
    }

    public static string ConvertToString(BigInteger val)
    {
        BigInteger remains, retVal;
        ModsForMoney mod = ConvertToMod(val,out retVal, out remains);
        remains = remains / 10;
        return retVal.ToString() + (remains > 0 ? "," + remains.ToString() : "") + VALS[mod];
    }
}

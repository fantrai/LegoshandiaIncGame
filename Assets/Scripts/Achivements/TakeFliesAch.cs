using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class TakeFliesAch : AbstractAchivement
{
    [SerializeField, Range(0, 999)] uint[] takeFliesOnLvl;
    [SerializeField] ModsForMoney[] modifTakeFliesOnLvl;

    protected override bool TryGetCollect(out float proc)
    {
        BigInteger needVal = MONEYS.ConvertToBigInt(takeFliesOnLvl[count], modifTakeFliesOnLvl[count], 0);
        proc = (float)((SaveManager.save.takeFlies * 100) / (needVal * 100)) / 100f;
        if (needVal <= SaveManager.save.takeFlies)
        {
            return true;
        }
        else { return false; }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class TakeFliesAch : AbstractAchivement
{
    [SerializeField, Range(1, 999)] uint[] takeFliesOnLvl;
    [SerializeField] ModsForMoney[] modifTakeFliesOnLvl;

    protected override void Status(out float proc)
    {
        BigInteger needVal = MONEYS.ConvertToBigInt(takeFliesOnLvl[count], modifTakeFliesOnLvl[count], 0);
        proc = (float)(SaveManager.save.takeFlies / (needVal / 100));
    }
}

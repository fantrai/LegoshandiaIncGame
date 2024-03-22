using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class StaticPurchase : AbstractStaticPunchase
{
    [Header("Стоимость")]
    [SerializeField, Range(10, 999)] uint startCostFlies = 10;
    [SerializeField] ModsForMoney mod = 0;

    protected override BigInteger costFlies { get => MONEYS.ConvertToBigInt(startCostFlies, mod, 0) + (MONEYS.ConvertToBigInt(startCostFlies, mod, 0) * count * addProcientCostForBuy / 100); }
    protected override uint costGoldFlies { get => 0; }
}

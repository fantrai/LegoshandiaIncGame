using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

/// <summary>
/// ���������� ��������� �� ������� ���
/// </summary>
public class GoldStaticPurchase : AbstractStaticPurchase
{
    [Header("���������")]
    [SerializeField] uint startCostGoldFlies = 1;

    protected override BigInteger costFlies => 0;
    protected override uint costGoldFlies => startCostGoldFlies + (startCostGoldFlies * count * addProcientCostForBuy / 100);
}

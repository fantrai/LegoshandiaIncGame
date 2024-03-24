using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// покупка мух за золотые мухи
/// </summary>
public class BuyFlies : AbstractPurchase
{
    [SerializeField, Range(1, 999)] protected uint addFlies;
    [SerializeField] ModsForMoney modFlies = 0;
    [SerializeField] uint costGoldFly = 0;

    protected override bool Buy()
    {
        if (GameManager.manager.BuyForGoldFlies(costGoldFly))
        {
            GameManager.manager.AddFlies(MONEYS.ConvertToBigInt(addFlies, modFlies, 0));
            return true;
        }
        else 
        { 
            return false; 
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;

/// <summary>
/// покупка мух за золотые мухи
/// </summary>
public class BuyFlies : AbstractPurchase
{
    [SerializeField] uint countFliesInHourWork;
    [SerializeField] uint costGoldFly = 0;
    [SerializeField] TextMeshProUGUI countBuyFliesText;
    BigInteger countBuyFlies = 0;

    private void OnEnable()
    {
        countBuyFlies = new BigInteger(countFliesInHourWork * SaveManager.save.speedEating) * SaveManager.save.fliesForFly;
        countBuyFliesText.text = MONEYS.ConvertToString(countBuyFlies);
    }

    protected override bool Buy()
    {
        if (GameManager.manager.BuyForGoldFlies(costGoldFly))
        {
            GameManager.manager.AddFlies(countBuyFlies);
            return true;
        }
        else 
        { 
            return false; 
        }
    }
}

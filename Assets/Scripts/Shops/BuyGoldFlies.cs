using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// покупка золотых мух за реальные деньги [В РАЗРАБОТКЕ]
/// </summary>
public class BuyGoldFlies : AbstractPurchase
{
    [SerializeField] uint addGoldFlies;
    bool buyProv = true;
    protected override bool Buy()
    {
        if (buyProv)
        {
            GameManager.manager.AddGoldFlies(addGoldFlies);
            return true;
        }
        else
        {
            return false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������� ������� ��� �� �������� ������ [� ����������]
/// </summary>
public class BuyGoldFlies : AbstractPurchase
{
    [SerializeField] uint addGoldFlies;
    protected override bool Buy()
    {
        if (true)
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

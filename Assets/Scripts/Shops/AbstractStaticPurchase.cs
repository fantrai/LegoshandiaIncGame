using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

/// <summary>
/// абстракция для постоянных покупок
/// </summary>
public abstract class AbstractStaticPurchase : AbstractPurchase
{
    [SerializeField, Range(-1, 1000)] protected int maxCount = 100;
    [SerializeField, Range(0, 100)] protected uint addProcientCostForBuy = 0;
    [Header("Мухи")]
    [SerializeField] uint addFliesPerSecond = 0;
    [SerializeField] uint addPliesPerClick = 0;
    [SerializeField, Range(0, 999)] uint addFliesForFly = 0;
    [SerializeField] ModsForMoney modifForAddFliesForFly = 0;
    [SerializeField, Range(0, 999)] uint addPassiveFliesPerSecond = 0;
    [SerializeField] ModsForMoney modifForAddPassiveFliesPerSecond = 0;
    [SerializeField] float addWaitFlies = 0;
    [SerializeField] uint addGoldForGoldFly = 0;
    [Header("Легушка")]
    [SerializeField] float addSpeedEating = 0;
    [Header("Крутость")]
    [SerializeField] uint addCoolness = 0;
    [Header("UI")]
    [SerializeField] TextMeshProUGUI buyButtonText;
    [SerializeField] TextMeshProUGUI buyAllButtonText;
    protected uint count = 0;

    abstract protected BigInteger costFlies { get;}
    abstract protected uint costGoldFlies { get; }

    private void Start()
    {
        if (SaveManager.save.punchases.TryGetValue(namingSave, out uint countVal))
        {
            count = countVal;
        }
        
        if (costFlies != 0)
        {
            buyButtonText.text = MONEYS.ConvertToString(costFlies);
        }
        else if (costGoldFlies != 0)
        {
            buyButtonText.text = costGoldFlies.ToString();
        }
    }

    private void OnEnable()
    {
        StartCoroutine(UpdateCountMaxBuy());
    }

    protected override bool Buy()
    {
        if (count < maxCount)
        {
            if (costFlies != 0)
            {
                if (GameManager.manager.BuyForFlies(costFlies))
                {
                    UpdateSave();
                    buyButtonText.text = MONEYS.ConvertToString(costFlies);
                    return true;
                }
            }
            else if (costGoldFlies != 0)
            {
                if (GameManager.manager.BuyForGoldFlies(costGoldFlies))
                {
                    UpdateSave();
                    buyButtonText.text = costGoldFlies.ToString();
                    return true;
                }
            }
        }
        return false;
    }

    public void BuyAll()
    {
        while (Buy());
    }

    public void BuyOne()
    {
        Buy();
    }

    void UpdateSave()
    {
        count++;
        var save = SaveManager.save;
        save.fliesPerSecond += addFliesPerSecond;
        save.fliesPerClick += addPliesPerClick;
        save.fliesForFly += MONEYS.ConvertToBigInt(addFliesForFly, modifForAddFliesForFly, 0);
        save.passivFliesPerSecond += MONEYS.ConvertToBigInt(addPassiveFliesPerSecond, modifForAddPassiveFliesPerSecond, 0);
        save.waitFlies += addWaitFlies;
        save.goldFliesForGoldFly += addGoldForGoldFly;
        save.speedEating += addSpeedEating;
        GameManager.manager.AddCoolness(addCoolness);
        if(!save.punchases.TryAdd(namingSave, count)) save.punchases[namingSave] = count;
        SaveManager.SaveData();
    }

    IEnumerator UpdateCountMaxBuy()
    {
        if (costFlies != 0)
        {
            do
            {
                BigInteger sum = costFlies;
                uint startCount = count;
                for (int i = 0; sum < SaveManager.save.flies; i++)
                {
                    sum += costFlies;
                    count++;
                }
                buyAllButtonText.text = "+"+(count - startCount).ToString();
                count = startCount;
                yield return new WaitForSeconds(1);
            } while (true);
        }
        else if (costGoldFlies != 0)
        {
            do
            {
                uint sum = 0;
                uint startCount = count;
                for (int i = 0; sum < SaveManager.save.goldFlies; i++)
                {
                    sum += costGoldFlies;
                    count++;
                }
                buyAllButtonText.text ="+"+ (count - startCount).ToString();
                count = startCount;
                yield return new WaitForSeconds(1);
            } while (true);
        }
        yield return new WaitForFixedUpdate();
    }
}

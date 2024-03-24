using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// базовая абстракция для всех покупок
/// </summary>
public abstract class AbstractPurchase : MonoBehaviour
{
    [SerializeField] protected string namingSave;
    [Header("Настройки покупки")]
    public uint minLvlForBuy = 1;

    abstract protected bool Buy();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������� ���������� ��� ���� �������
/// </summary>
public abstract class AbstractPurchase : MonoBehaviour
{
    [SerializeField] protected string namingSave;
    [Header("��������� �������")]
    public uint minLvlForBuy = 1;

    abstract protected bool Buy();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// управление отображением слотов покупок в соответствии с текущим уровнем
/// </summary>
public class PurchaseList : MonoBehaviour
{
    List<GameObject> purchases = new List<GameObject>();

    private void OnEnable()
    {
        GameManager.OnNewLvl += UpdateList;
    }

    private void OnDisable()
    {
        GameManager.OnNewLvl -= UpdateList;
    }

    private void Start()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            GameObject child = gameObject.transform.GetChild(i).gameObject;
            if (child.TryGetComponent(out AbstractPurchase purchase))
            {
                purchases.Add(child);
            }
        }
        UpdateList();
    }

    private void UpdateList()
    {
        foreach (GameObject child in purchases)
        {
            if (child.GetComponent<AbstractPurchase>().minLvlForBuy <= SaveManager.save.LvlCoolness)
            {
                child.SetActive(true);
            }
            else
            {
                child.SetActive(false);
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;

/// <summary>
/// все, что касается общего взаимодействия с UI
/// </summary>
public class UIManager : MonoBehaviour
{
    public static Action OnNewGoldFliesScore;

    [SerializeField] int countUpdateFliesPerSecond = 1;
    [SerializeField] TextMeshProUGUI[] fliesText;
    [SerializeField] TextMeshProUGUI[] goldFliesText;

    private void OnEnable()
    {
        OnNewGoldFliesScore += GoldFliesScoreUpdate;
    }

    private void OnDisable()
    {
        OnNewGoldFliesScore -= GoldFliesScoreUpdate;
    }

    private void Start()
    {
        StartCoroutine(ScoreUpdater());
    }

    IEnumerator ScoreUpdater()
    {
        do
        {
            foreach (var item in fliesText)
            {
                item.text = MONEYS.ConvertToString(SaveManager.save.flies);
            }
            yield return new WaitForSeconds(1 / countUpdateFliesPerSecond);
        } while (true);
    }

    void GoldFliesScoreUpdate()
    {
        foreach(var item in goldFliesText)
        {
            item.text = SaveManager.save.goldFlies.ToString();

        }
    }
}

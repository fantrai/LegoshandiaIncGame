using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// все, что касается общего взаимодействия с UI
/// </summary>
public class UIManager : MonoBehaviour
{
    public static Action OnNewGoldFliesScore;
    public static Action OnAddCoolness;

    [SerializeField] int countUpdateFliesPerSecond;
    [SerializeField] TextMeshProUGUI[] fliesText;
    [SerializeField] TextMeshProUGUI[] goldFliesText;
    [SerializeField] TextMeshProUGUI passiveFliesPerSecondText;
    [SerializeField] TextMeshProUGUI waitTimeFliesText;
    [SerializeField] Slider coolnessSlider;

     private void OnEnable()
    {
        OnNewGoldFliesScore += GoldFliesScoreUpdate;
        GameManager.OnAddCoolness += UpdateCoolnessSlider;
    }

    private void OnDisable()
    {
        OnNewGoldFliesScore -= GoldFliesScoreUpdate;
        GameManager.OnAddCoolness -= UpdateCoolnessSlider;
    }

    private void Start()
    {
        StartCoroutine(ScoreUpdater());
        UpdateCoolnessSlider();
        OnNewGoldFliesScore();
    }

    void UpdateCoolnessSlider()
    {
        coolnessSlider.maxValue = SaveManager.save.coolnessBeforeNextLvl;
        coolnessSlider.value = SaveManager.save.coolness;
    }

    IEnumerator ScoreUpdater()
    {
        do
        {
            foreach (var item in fliesText)
            {
                item.text = MONEYS.ConvertToString(SaveManager.save.flies);
            }
            passiveFliesPerSecondText.text = "+" + MONEYS.ConvertToString(SaveManager.save.passivFliesPerSecond) + "мух/сек";
            waitTimeFliesText.text = Math.Round(SaveManager.save.waitFlies, 2) + " сек";
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

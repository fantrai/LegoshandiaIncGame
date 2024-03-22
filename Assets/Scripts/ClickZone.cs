using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ClickZone : MonoBehaviour
{
    [SerializeField] uint stepCombo;
    [SerializeField] uint maxCombo;
    [SerializeField] float timeCombo;
    [SerializeField] float clickForLoseCombo = 1;
    uint countClick = 0;
    uint comboBonus = 1;

    private void Start()
    {
        StartCoroutine(CheckCombo());
    }

    public void OnClick()
    {
        countClick++;
        comboBonus += countClick / (stepCombo * comboBonus);
        comboBonus = comboBonus > 0 ? comboBonus : 1;
        comboBonus = comboBonus <= maxCombo ? comboBonus : maxCombo;

        GameManager.manager.CreateNewFly(SaveManager.save.fliesPerClick * comboBonus);
    }

    IEnumerator CheckCombo()
    {
        do
        {
            uint lastCountClick = countClick;
            yield return new WaitForSecondsRealtime(timeCombo);
            if (countClick - clickForLoseCombo <= lastCountClick)
            {
                countClick = 0;
                comboBonus = 1;
            }
        } while (true);
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] int countUpdateFliesPerSecond = 1;
    [SerializeField] TextMeshProUGUI fliesText;
    [SerializeField, Tooltip("текстовые модификаторы к счету за каждую 1000")] string[] modifWithScore;

    private void Start()
    {
        StartCoroutine(ScoreUpdater());
    }

    IEnumerator ScoreUpdater()
    {
        do
        {
            fliesText.text = ConvertFliesToText(SaveManager.save.flies);
            yield return new WaitForSeconds(1 / countUpdateFliesPerSecond);
        } while (true);
    }

    public string ConvertFliesToText(BigInteger val)
    {
        BigInteger retVal = val;
        int countDiv = 0;
        BigInteger remains = 0;
        while (retVal > 1000)
        {
            retVal = BigInteger.DivRem(retVal, 1000,out remains);
            countDiv++;
        }
        remains = remains / 10;
        return retVal.ToString() + (remains > 0 ? "," + remains.ToString() : "") + modifWithScore[countDiv];
    }
}

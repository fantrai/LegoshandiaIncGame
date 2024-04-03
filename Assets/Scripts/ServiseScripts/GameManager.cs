using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;

/// <summary>
/// общее управление игрой, принятие и проверка важнейших решений
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager manager;
    public static Action OnNewLvl;

    public List<IFood> foodList = new List<IFood>();

    [SerializeField] float rateNewLvl;
    [SerializeField] float chanceGoldFly;
    [SerializeField] GameObject flyPrefab;
    [SerializeField] GameObject goldFlyPrefab;
    [SerializeField] GameObject mainFrog;

    private void Awake()
    {
        if (manager != null)
        {
            Destroy(manager);
        }
        manager = this;
        AudioListener.pause = SaveManager.save.music;
    }

    private void Start()
    {
        StartCoroutine(FliesPerSecond());
        StartCoroutine(PassivFlies());
    }

    private void OnApplicationPause(bool pause)
    {
        SaveManager.SaveData();
    }

    private void OnApplicationQuit()
    {
        SaveManager.SaveData();
    }

    public void CreateNewFly(uint count, float modChanceGoldfly)
    {
        for (int i = 0; i < count; i++)
        {
            Vector2 spavnPos = Random.insideUnitCircle * (Camera.main.orthographicSize / 2);
            GameObject fly;
            if (Random.value * 100 <= chanceGoldFly)
            {
                fly = Instantiate(goldFlyPrefab, spavnPos, goldFlyPrefab.transform.rotation);
            }
            else
            {
                fly = Instantiate(flyPrefab, spavnPos, flyPrefab.transform.rotation);
            }
            foodList.Add(fly.GetComponent<IFood>());
        }
    }

    public void AddFlies(BigInteger count)
    {
        SaveManager.save.flies += count;
    }

    public void AddGoldFlies(uint count)
    {
        SaveManager.save.goldFlies += count;
        UIManager.OnNewGoldFliesScore();
        SaveManager.SaveData();
    }

    public bool BuyForFlies(BigInteger cost)
    {
        if (SaveManager.save.flies >= cost)
        {
            SaveManager.save.flies -= cost;
            SaveManager.SaveData();
            return true;
        }
        else 
        { 
            return false; 
        }
    }

    public bool BuyForGoldFlies(uint cost)
    {
        if (SaveManager.save.goldFlies >= cost)
        {
            SaveManager.save.goldFlies -= cost;
            UIManager.OnNewGoldFliesScore();
            SaveManager.SaveData();
            return true;
        }
        else
        {
            return false;
        }
    }

    public void AddCoolness(uint val)
    {
        var save = SaveManager.save;
        save.coolness += val;
        if (save.coolness > save.coolnessBeforeNextLvl)
        {
            save.LvlCoolness++;
            save.coolness -= save.coolnessBeforeNextLvl;
            save.coolnessBeforeNextLvl = (uint)(save.coolnessBeforeNextLvl * rateNewLvl);
            SaveManager.SaveData();
        }
    }

    IEnumerator FliesPerSecond()
    {
        do
        {
            if (SaveManager.save.fliesPerSecond > 0)
            {
                CreateNewFly(1, 1);
            }
            float sleepTime = (float)(SaveManager.save.fliesPerSecond == 0 ? 1 : 1f / SaveManager.save.fliesPerSecond);
            yield return new WaitForSeconds(sleepTime);
        } while (true);
    }

    IEnumerator PassivFlies()
    {
        do
        {
            SaveManager.save.flies += SaveManager.save.passivFliesPerSecond;
            SaveManager.save.timeInGame = SaveManager.save.timeInGame.AddSeconds(1);
            yield return new WaitForSeconds(1);
        } while (true);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;

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
    }

    private void Start()
    {
        StartCoroutine(FliesPerSecond());
    }

    public void CreateNewFly(uint count, Vector2 pos)
    {
        GameObject fly;
        if (Random.value * 100 <= chanceGoldFly)
        {
            fly = Instantiate(goldFlyPrefab, pos, goldFlyPrefab.transform.rotation);
        }
        else
        {
            fly = Instantiate(flyPrefab, pos, flyPrefab.transform.rotation);
        }
        foodList.Add(fly.GetComponent<IFood>());
    }

    public void AddFlies(BigInteger count)
    {
        SaveManager.save.flies += count;
    }

    public void AddGoldFlies(uint count) 
    {
        SaveManager.save.goldFliesForGoldFly += count;
    }

    public bool BuyForFlies(BigInteger cost)
    {
        if (SaveManager.save.flies >= cost)
        {
            SaveManager.save.flies -= cost;
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
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator FliesPerSecond()
    {
        do
        {
            if (SaveManager.save.fliesPerSecond > 0)
            {
                CreateNewFly(1, Random.insideUnitCircle * (Camera.main.orthographicSize / 2));
            }
            float sleepTime = (float)(SaveManager.save.fliesPerSecond == 0 ? 1 : 1f / SaveManager.save.fliesPerSecond);
            yield return new WaitForSeconds(sleepTime);
        } while (true);
    }
}

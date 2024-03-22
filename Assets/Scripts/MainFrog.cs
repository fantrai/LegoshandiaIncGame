using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainFrog : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Eating());
    }

    IEnumerator Eating()
    {
        do
        {
            if (GameManager.manager.foodList.Count > 0)
            {
                GameManager.manager.foodList[Random.Range(0, GameManager.manager.foodList.Count)].Eat();
            }
            yield return new WaitForSeconds(1 / SaveManager.save.speedEating);
        } while (true);
    }
}

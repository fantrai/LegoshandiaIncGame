using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractAchivement : MonoBehaviour
{
    [SerializeField] protected Slider slider;
    [SerializeField] protected string namingSave;
    [SerializeField] protected uint[] coolnessOnLvl;
    protected uint count = 0;
    protected bool getCollect = false;

    private void Start()
    {
        if (SaveManager.save.achivements.TryGetValue(namingSave, out uint countVal))
        {
            count = countVal;
        }
    }

    private void OnEnable()
    {
        getCollect = TryGetCollect(out float proc);
        UpdateSlider(proc);
    }

    abstract protected bool TryGetCollect(out float proc);

    public void CollectAchivement()
    {
        if (getCollect)
        {
            if (count + 1 < coolnessOnLvl.Length)
            {
                count++;
                GameManager.manager.AddCoolness(coolnessOnLvl[count]);
                var save = SaveManager.save;
                if (!save.achivements.TryAdd(namingSave, count)) save.achivements[namingSave] = count;
                SaveManager.SaveData();
            }
        }
    }

    void UpdateSlider(float proc)
    {
        slider.value = slider.maxValue / 100 * proc;
    }
}

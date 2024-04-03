using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractAchivement : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] string saveName;
    [SerializeField] uint[][] lvls;
}

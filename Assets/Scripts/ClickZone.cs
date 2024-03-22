using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ClickZone : MonoBehaviour
{
    public void OnClick()
    {
        GameManager.manager.CreateNewFly(SaveManager.save.fliesPerClick, Camera.main.ScreenToWorldPoint(Input.touches.Last().position));
    }
}

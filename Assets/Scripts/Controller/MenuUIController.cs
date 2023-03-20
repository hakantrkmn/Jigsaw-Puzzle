using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuUIController : MonoBehaviour
{
    public TMP_Dropdown dropDown;
    void Start()
    {
        dropDown.value = (int)EventManager.GetLevelData().puzzleSize;
    }

   
}

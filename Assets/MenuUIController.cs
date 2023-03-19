using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuUIController : MonoBehaviour
{
    public TMP_Dropdown dropDown;
    // Start is called before the first frame update
    void Start()
    {
        dropDown.value = EventManager.GetLevelDatas().puzzleSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

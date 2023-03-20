using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public LevelData levelData;


    private void OnEnable()
    {
        //return leveldata if needed
        EventManager.GetLevelData += GetLevelDatas;
    }

    private LevelData GetLevelDatas()
    {
        return levelData;
    }
}

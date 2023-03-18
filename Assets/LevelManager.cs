using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public LevelDatas levelData;


    private void OnEnable()
    {
        EventManager.GetLevelDatas += GetLevelDatas;
    }

    private LevelDatas GetLevelDatas()
    {
        return levelData;
    }
}

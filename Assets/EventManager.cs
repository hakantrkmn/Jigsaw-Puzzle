using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class EventManager
{
    public static Func<List<PuzzlePiece>> GetPuzzlePieces;
    public static Func<LevelDatas> GetLevelDatas;
    public static Action TakePhotoButton;

}

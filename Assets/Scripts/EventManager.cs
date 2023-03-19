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
    public static Action<PuzzlePiece> PiecePlaced;
    public static Action LevelWin;
    public static Action PlaceRandomPiece;
    public static Action<bool> ShowPuzzle;
    public static Action PuzzleReady;



}

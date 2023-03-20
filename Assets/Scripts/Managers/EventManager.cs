using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class EventManager
{
    //get all puzzle pieces
    public static Func<List<PuzzlePiece>> GetPuzzlePieces;
    //get data about level
    public static Func<LevelData> GetLevelData;
    public static Action TakePhotoButton;
    public static Action<PuzzlePiece> PiecePlaced;
    // level completed
    public static Action LevelWin;
    
    // place a random piece 
    public static Action PlaceRandomPiece;
    
    //show completed puzzle
    public static Action<bool> ShowPuzzle;
    
    //puzzle ready to solve
    public static Action PuzzleReady;



}

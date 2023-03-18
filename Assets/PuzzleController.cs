using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PuzzleController : MonoBehaviour
{
    public List<PuzzlePiece> pieces;


    private void OnEnable()
    {
        EventManager.GetPuzzlePieces += GetPuzzlePieces;
    }

    private List<PuzzlePiece> GetPuzzlePieces()
    {
        return pieces;
    }

    private void Awake()
    {
        var levelSprite = EventManager.GetLevelDatas().levelSprites[0];
        foreach (var piece in pieces)
        {
            piece.transform.GetChild(0).GetComponent<Image>().sprite = levelSprite;
        }
    }

    private void OnValidate()
    {
        pieces.Clear();
        foreach (var piece in GetComponentsInChildren<PuzzlePiece>())
        {
            pieces.Add(piece);
        }
    }
    
}

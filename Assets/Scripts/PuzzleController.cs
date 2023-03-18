using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PuzzleController : MonoBehaviour
{
    public List<PuzzlePiece> pieces;
    public Image wholePuzzle;

    private void OnEnable()
    {
        EventManager.ShowPuzzle += ShowPuzzle;
        EventManager.PlaceRandomPiece += PlaceRandomPiece;
        EventManager.PiecePlaced += PiecePlaced;
        EventManager.GetPuzzlePieces += GetPuzzlePieces;
    }

    private void ShowPuzzle(bool canShow)
    {
        if (canShow)
        {
            wholePuzzle.enabled = true;
        }
        else
        {
            wholePuzzle.enabled = false;
        }
    }

    private void PlaceRandomPiece()
    {
        pieces[Random.Range(0,pieces.Count)].PlacePieceOnPos();
    }

    private void OnDisable()
    {
        EventManager.ShowPuzzle -= ShowPuzzle;
        EventManager.PlaceRandomPiece -= PlaceRandomPiece;
        EventManager.PiecePlaced -= PiecePlaced;
    }

    private void PiecePlaced(PuzzlePiece obj)
    {
        pieces.Remove(obj);
        if (pieces.Count==0)
        {
            EventManager.LevelWin();
        }
    }

    private List<PuzzlePiece> GetPuzzlePieces()
    {
        return pieces;
    }

    private void Awake()
    {
        if (EventManager.GetLevelDatas().playersPhoto.Count!=0)
        {
            Texture2D tex = null;
            tex = new Texture2D(2, 2); 
            tex.LoadImage(EventManager.GetLevelDatas().playersPhoto.ToArray()); 
            var temp = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.zero);;
            foreach (var piece in pieces)
            {
                piece.transform.GetChild(0).GetComponent<Image>().sprite = temp;
            }

            wholePuzzle.sprite = temp;
        }
        else
        {
            var levelSprite = EventManager.GetLevelDatas().levelSprites[EventManager.GetLevelDatas().spriteIndex];
            foreach (var piece in pieces)
            {
                piece.transform.GetChild(0).GetComponent<Image>().sprite = levelSprite;
            }
            wholePuzzle.sprite = levelSprite;

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

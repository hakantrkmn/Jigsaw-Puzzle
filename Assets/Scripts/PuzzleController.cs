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


    private void Start()
    {
        GetPuzzleReady();
    }

    private void OnEnable()
    {
        EventManager.ShowPuzzle += ShowPuzzle;
        EventManager.PlaceRandomPiece += PlaceRandomPiece;
        EventManager.PiecePlaced += PiecePlaced;
        EventManager.GetPuzzlePieces += GetPuzzlePieces;
    }

    private void ShowPuzzle(bool canShow) // show completed puzzle
    {
        wholePuzzle.enabled = canShow;
    }

    private void PlaceRandomPiece()
    {
        pieces[Random.Range(0, pieces.Count)].PlacePieceOnPos();
    }

    public void GetPuzzleReady()
    {
        if (EventManager.GetLevelDatas().playersPhoto.Count != 0) //upload player photo
        {
            Texture2D tex = null;
            tex = new Texture2D(2, 2);
            tex.LoadImage(EventManager.GetLevelDatas().playersPhoto.ToArray());
            var temp = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.zero);
            ;
            foreach (var piece in pieces)
            {
                piece.transform.GetChild(0).GetComponent<Image>().sprite = temp;
            }

            wholePuzzle.sprite = temp;
        }
        else // place choosen photo
        {
            var levelSprite = EventManager.GetLevelDatas().levelSprites[EventManager.GetLevelDatas().spriteIndex];
            foreach (var piece in pieces)
            {
                piece.transform.GetChild(0).GetComponent<Image>().sprite = levelSprite;
            }

            wholePuzzle.sprite = levelSprite;
        }

        transform.localScale = new Vector3(((float)(Screen.width * .9f) / GetComponent<RectTransform>().rect.width), (Screen.height*.5f)/GetComponent<RectTransform>().rect.height, 1);

        foreach (var piece in pieces)
        {
            piece.stat.correctPosition = piece.transform.position;
        }

        EventManager.PuzzleReady();
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
        if (pieces.Count == 0)
        {
            EventManager.LevelWin();
        }
    }

    private List<PuzzlePiece> GetPuzzlePieces()
    {
        return pieces;
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
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ScrollController : MonoBehaviour
{
    public Transform content;


    private void OnEnable()
    {
        EventManager.PuzzleReady += PuzzleReady;
    }

    private void OnDisable()
    {
        EventManager.PuzzleReady -= PuzzleReady;
    }

    private void PuzzleReady()
    {
        SetScroll();
    }

    private void Start()
    {
    }


    void SetScroll()
    {
        var pieces = EventManager.GetPuzzlePieces();

        foreach (var piece in pieces)
        {
            piece.transform.parent = content;
            piece.transform.SetSiblingIndex(Random.Range(0, pieces.Count));
        }
    }
}
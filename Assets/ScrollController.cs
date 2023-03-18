using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ScrollController : MonoBehaviour
{
    public Transform content;


    private void Start()
    {
        SetScroll();
    }


    public void SetScroll()
    {
        var pieces = EventManager.GetPuzzlePieces();

        foreach (var piece in pieces)
        {
            piece.transform.parent = content;
            piece.transform.SetSiblingIndex(Random.Range(0,pieces.Count));
        }
        
        
    }
}

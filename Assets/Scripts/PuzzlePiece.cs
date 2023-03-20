using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PuzzlePiece : ItemBase, IInteractable
{
    public PuzzlePieceStats stat;
    public Image puzzleImage;
    Transform puzzleBoard;

    private bool choosenPiece;


    private void Start()
    {
        puzzleImage = transform.GetChild(0).GetComponent<Image>();
        puzzleBoard = GameObject.FindObjectOfType<PuzzleController>().transform;
    }


    private void Update()
    {
        if (choosenPiece)
        {
            // if current pos close enough to right position, place it
            if (Vector3.Distance(transform.position, stat.correctPosition) < 50)
            {
                PlaceItemOnPos();
            }
        }
    }


    public override void PlaceItemOnPos()
    {
        transform.parent = puzzleBoard;
        transform.position = stat.correctPosition;
        stat.isPlaced = true;
        choosenPiece = false;
        EventManager.PiecePlaced(this);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        choosenPiece = false;
        
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        if (choosenPiece)
        {
            transform.position = Input.mousePosition + Vector3.forward;
        }
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        if (!stat.isPlaced)
        {
            choosenPiece = true;
            transform.parent = puzzleBoard;
        }
    }
}
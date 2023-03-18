using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PuzzlePiece : MonoBehaviour, IPointerUpHandler, IPointerMoveHandler, IPointerDownHandler
{
    public PuzzlePieceStats stat;
    public Image puzzleImage;
    public Transform puzzleBoard;

    private bool choosenPiece;


    private void Start()
    {
        puzzleImage = transform.GetChild(0).GetComponent<Image>();
        puzzleBoard = GameObject.FindObjectOfType<PuzzleController>().transform;
    }

    public void PlacePieceOnPos()
    {
        transform.parent = puzzleBoard;
        transform.position = stat.correctPosition;
        stat.isPlaced = true;
        choosenPiece = false;
        EventManager.PiecePlaced(this);
    }

    private void OnValidate()
    {
        stat.correctPosition = transform.position;
    }

    private void Update()
    {
        if (choosenPiece)
        {
            if (Vector3.Distance(transform.position, stat.correctPosition) < 50)
            {
                PlacePieceOnPos();
            }
        }
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        choosenPiece = false;
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        if (choosenPiece)
        {
            transform.position = Input.mousePosition;
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
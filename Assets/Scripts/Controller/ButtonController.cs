using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public ButtonTypes buttonType;

    

    public void ButtonClicked()
    {
        switch (buttonType)
        {
            case ButtonTypes.TakePhoto:
                EventManager.TakePhotoButton();
                break;
            case ButtonTypes.MenuButton:
                SceneManager.LoadScene(0);
                break;
            case ButtonTypes.PlacePiece:
                EventManager.PlaceRandomPiece();
                break;
        }
    }
    
    public void OnDropDownChanged(TMP_Dropdown dropDown)
    {
        // if dropdown value change, update leveldata 
        if (dropDown.value==0)
        {
            EventManager.GetLevelData().puzzleSize = PuzzleSizes.Puzzle4x4;
        }
        else
        {
            EventManager.GetLevelData().puzzleSize = PuzzleSizes.Puzzle6x6;

        }
    }
    public void LevelButtonClicked(int index)
    {
        
        EventManager.GetLevelData().playersPhoto.Clear();
        EventManager.GetLevelData().spriteIndex = index;
        if (EventManager.GetLevelData().puzzleSize==0)
        {
            SceneManager.LoadScene(1);

        }
        else
        {
            SceneManager.LoadScene(2);

        }
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        if (buttonType == ButtonTypes.ShowPicture)
        {
            EventManager.ShowPuzzle(true);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (buttonType == ButtonTypes.ShowPicture)
        {
            EventManager.ShowPuzzle(false);
        }
    }
}
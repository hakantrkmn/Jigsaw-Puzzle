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
        EventManager.GetLevelDatas().puzzleSize = dropDown.value;
    }
    public void LevelButtonClicked(int index)
    {
        EventManager.GetLevelDatas().playersPhoto.Clear();
        EventManager.GetLevelDatas().spriteIndex = index;
        if (EventManager.GetLevelDatas().puzzleSize==0)
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
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

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

    public void LevelButtonClicked(int index)
    {
        EventManager.GetLevelDatas().playersPhoto.Clear();
        EventManager.GetLevelDatas().spriteIndex = index;
        SceneManager.LoadScene(1);
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
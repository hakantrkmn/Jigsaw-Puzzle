using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ImagePicker : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.TakePhotoButton += PickImage;
    }

    private void OnDisable()
    {
        EventManager.TakePhotoButton -= PickImage;
    }

    public void PickImage() // work on editor, take picture from user. save this picture byte on leveldata.
    {                       
        #if UNITY_EDITOR
        string path = EditorUtility.OpenFilePanel("Overwrite with png", "", "png");
        Texture2D tex = null;
        byte[] fileData;
 
        if (File.Exists(path))     {
            fileData = File.ReadAllBytes(path);
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData); //..t$$anonymous$$s will auto-resize the texture dimensions.
            EventManager.GetLevelData().playersPhoto=(fileData.ToList());
            if (EventManager.GetLevelData().puzzleSize==0)
            {
                SceneManager.LoadScene(1);

            }
            else
            {
                SceneManager.LoadScene(2);

            }
        }
        #endif

    }
    
    
}

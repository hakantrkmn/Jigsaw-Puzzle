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

    public void PickImage()
    {
        string path = EditorUtility.OpenFilePanel("Overwrite with png", "", "png");
        Texture2D tex = null;
        byte[] fileData;
 
        if (File.Exists(path))     {
            fileData = File.ReadAllBytes(path);
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData); //..t$$anonymous$$s will auto-resize the texture dimensions.
            EventManager.GetLevelDatas().playersPhoto=(fileData.ToList());
            if (EventManager.GetLevelDatas().puzzleSize==0)
            {
                SceneManager.LoadScene(1);

            }
            else
            {
                SceneManager.LoadScene(2);

            }
        }

    }
    
    
}

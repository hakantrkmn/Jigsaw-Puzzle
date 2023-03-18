using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class FileTest : MonoBehaviour
{
    public Image image;
    private void Start()
    {
        string path = EditorUtility.OpenFilePanel("Overwrite with png", "", "png");
        Texture2D tex = null;
        byte[] fileData;
 
        if (File.Exists(path))     {
            fileData = File.ReadAllBytes(path);
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData); //..t$$anonymous$$s will auto-resize the texture dimensions.
        }

        image.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.zero);;
        Debug.Log(path);
    }

    [MenuItem("Example/Overwrite Texture")]
    static void Apply()
    {
        Texture2D texture = Selection.activeObject as Texture2D;
        if (texture == null)
        {
            EditorUtility.DisplayDialog("Select Texture", "You must select a texture first!", "OK");
            return;
        }

        string path = EditorUtility.OpenFilePanel("Overwrite with png", "", "png");
        if (path.Length != 0)
        {
            var fileContent = File.ReadAllBytes(path);
            texture.LoadImage(fileContent);
        }
    }
}

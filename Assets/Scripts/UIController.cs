using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject gamePanel;

    private void OnEnable()
    {
        EventManager.LevelWin += LevelWin;
    }

    private void OnDisable()
    {
        EventManager.LevelWin -= LevelWin;
    }

    private void LevelWin()
    {
        gamePanel.SetActive(false);
        winPanel.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GamePaused = false;
    public GameObject PauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        GamePaused = false;
        UnityEngine.Cursor.visible = false;
        Time.timeScale = 1f;
        PauseMenuUI.SetActive(false);
    }

    void PauseGame()
    {
        GamePaused = true;
        UnityEngine.Cursor.visible = true;
        Time.timeScale = 0f;
        PauseMenuUI.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

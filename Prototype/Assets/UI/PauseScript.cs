﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour {

    public enum PauseMenu
    {
        playtime,
        pauseMenu,
        optionsMenu,
        gameOverMenu
    }

    public bool paused;

    public GameObject pauseScreen;
    public GameObject optionsScreen;
    public GameObject gameOverScreen;

    private PauseMenu pauseMenu;
    private Stack<PauseMenu> pauseMenuStack = new Stack<PauseMenu>();

    private void Start()
    {
        pauseMenuStack.Push(PauseMenu.playtime);
        SetUpStates();
    }

    void SetUpStates()
    {
        switch (pauseMenuStack.Peek())
        {
            case PauseMenu.playtime:
                {
                    pauseScreen.SetActive(false);
                    optionsScreen.SetActive(false);
                    gameOverScreen.SetActive(false);
                    Time.timeScale = 1;
                }
                break;
            case PauseMenu.pauseMenu:
                {
                    pauseScreen.SetActive(true);
                    optionsScreen.SetActive(false);
                    gameOverScreen.SetActive(false);
                    Time.timeScale = 0;
                }
                break;
            case PauseMenu.optionsMenu:
                {
                    pauseScreen.SetActive(false);
                    optionsScreen.SetActive(true);
                    gameOverScreen.SetActive(false);
                    Time.timeScale = 0;
                }
                break;
            case PauseMenu.gameOverMenu:
                {
                    pauseScreen.SetActive(false);
                    optionsScreen.SetActive(false);
                    gameOverScreen.SetActive(true);
                    Time.timeScale = 0;
                }
                break;
            default:
                {
                    pauseScreen.SetActive(false);
                    optionsScreen.SetActive(false);
                    gameOverScreen.SetActive(false);
                    Time.timeScale = 1;
                }
                break;
        }
        Debug.Log(pauseMenuStack.Peek().ToString());
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused && pauseMenuStack.Peek() == PauseMenu.playtime)
            {
                paused = true;
                PauseGame();
            }
            else if(paused && pauseMenuStack.Peek() == PauseMenu.optionsMenu)
            {
                paused = true;
                PopState();
            }
            else if (paused && pauseMenuStack.Peek() == PauseMenu.pauseMenu)
            {
                paused = false;
                PopState();
            }
        }
    }

    public void StartGame()
    {
        PushState(PauseMenu.playtime);
    }

    public void ResumeGame()
    {
        pauseMenuStack.Clear();
        PushState(PauseMenu.playtime);
        paused = false;
    }

    public void PauseGame()
    {
        PushState(PauseMenu.pauseMenu);
    }

    public void OptionScreen()
    {
        PushState(PauseMenu.optionsMenu);
    }

    public void ExitMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        PushState(PauseMenu.gameOverMenu);
    }

    public void RetryLevel()
    {
        pauseMenuStack.Clear();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PopState()
    {
        pauseMenuStack.Pop();
        SetUpStates();
    }

    public void PushState(PauseMenu state)
    {
        Debug.Log(state);
        pauseMenuStack.Push(state);
        SetUpStates();
    }
}

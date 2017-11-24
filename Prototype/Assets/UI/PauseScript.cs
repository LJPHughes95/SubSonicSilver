using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour {

    public enum PauseMenu
    {
        playtime,
        pauseMenu,
        optionsMenu
    }

    public bool paused;

    public GameObject pauseScreen;
    public GameObject optionsScreen;

    private PauseMenu pauseMenu;
    private Stack<PauseMenu> pauseMenuStack = new Stack<PauseMenu>();

    private void Start()
    {
        //paused = false;
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
                    Time.timeScale = 1;
                }
                break;
            case PauseMenu.pauseMenu:
                {
                    pauseScreen.SetActive(true);
                    optionsScreen.SetActive(false);
                    Time.timeScale = 0;
                }
                break;
            case PauseMenu.optionsMenu:
                {
                    pauseScreen.SetActive(false);
                    optionsScreen.SetActive(true);
                    Time.timeScale = 0;
                }
                break;
            default:
                {
                    pauseScreen.SetActive(false);
                    optionsScreen.SetActive(false);
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

    public void PopState()
    {
        pauseMenuStack.Pop();
        SetUpStates();
    }


    public void PushState(PauseMenu state)
    {
        pauseMenuStack.Push(state);
        SetUpStates();
    }
}

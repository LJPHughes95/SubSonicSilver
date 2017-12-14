using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public enum Menu
    {
        startScreen,
        mainMenu,
        levelSelectMenu,
        optionsMenu,
        extrasMenu
    }

    public GameObject startScreen;
    public GameObject mainMenu;
    public GameObject levelSelectMenu;
    public GameObject optionsMenu;
    public GameObject extrasMenu;

    private Menu menu;
    private Stack<Menu> menuStack = new Stack<Menu>();

    void Start()
    {
		menuStack.Push(Menu.mainMenu);
        SetupStates();
    }


    void Update()
    {
        if (menuStack.Peek() == Menu.startScreen)
        {
            StartGame();
        }
    }


    void SetupStates()
    {
        switch (menuStack.Peek())
        {
            case Menu.startScreen:
                {
                    startScreen.SetActive(true);
                    mainMenu.SetActive(false);
                    levelSelectMenu.SetActive(false);
                    optionsMenu.SetActive(false);
                    extrasMenu.SetActive(false);
                }
                break;
            case Menu.mainMenu:
                {
                    startScreen.SetActive(false);
                    mainMenu.SetActive(true);
                    levelSelectMenu.SetActive(false);
                    optionsMenu.SetActive(false);
                    extrasMenu.SetActive(false);
                }
                break;
            case Menu.levelSelectMenu:
                {
                    startScreen.SetActive(false);
                    mainMenu.SetActive(false);
                    levelSelectMenu.SetActive(true);
                    optionsMenu.SetActive(false);
                    extrasMenu.SetActive(false);
                }
                break;
            case Menu.optionsMenu:
                {
                    startScreen.SetActive(false);
                    mainMenu.SetActive(false);
                    levelSelectMenu.SetActive(false);
                    optionsMenu.SetActive(true);
                    extrasMenu.SetActive(false);
                }
                break;
            case Menu.extrasMenu:
                {
                    startScreen.SetActive(false);
                    mainMenu.SetActive(false);
                    levelSelectMenu.SetActive(false);
                    optionsMenu.SetActive(false);
                    extrasMenu.SetActive(true);
                }
                break;
            default:
                {
                    startScreen.SetActive(false);
                    mainMenu.SetActive(true);
                    levelSelectMenu.SetActive(false);
                    optionsMenu.SetActive(false);
                    extrasMenu.SetActive(false);
                }
                break;
        }
    }

    public void StartGame()
    {
        if (Input.anyKeyDown)
        {
            PushState(Menu.mainMenu);
        }
    }

    public void PushState(Menu state)
    {
        menuStack.Push(state);
        SetupStates();
        //Debug.Log(menuStack.Peek().ToString());
    }

    public void ModeSelectMenu()
    {
        SceneManager.LoadScene(1);
        //PushState(Menu.levelSelectMenu);
    }
    
    public void OptionsMenu()
    {
        PushState(Menu.optionsMenu);
    }

    public void ExtrasMenu()
    {
        PushState(Menu.extrasMenu);
    }

    public void Back()
    {
        menuStack.Pop();
        SetupStates();
        //Debug.Log(menuStack.Peek().ToString());
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game Exit");
    }
}

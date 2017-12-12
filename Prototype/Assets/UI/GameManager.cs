using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static void PauseGame()
    {
        Debug.Log("Paused");
        Time.timeScale = 0;
    }

    public static void UnPauseGame()
    {
        Debug.Log("Unpaused");
        Time.timeScale = 1;
    }
}

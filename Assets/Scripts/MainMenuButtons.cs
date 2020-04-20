using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainMenuButtons : MonoBehaviour
{
    public void PlayGame()
    {
        Application.LoadLevel(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        Application.LoadLevel(0);
    }
}

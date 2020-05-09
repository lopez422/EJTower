﻿
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelSelector : MonoBehaviour
{
    public void LoadLevel1()
    {
    	SceneManager.LoadScene("MainLevel");
    }

    public void LoadLevel2()
    {
    	SceneManager.LoadScene("Level2");
    }

    public void LoadLevel3()
    {
    	SceneManager.LoadScene("Level3");
    }

    public void LoadLevel4()
    {
    	SceneManager.LoadScene("Level4");
    }

    public void EndGame()
    {
        Application.Quit();
    }

}

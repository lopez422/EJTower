using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{

    public string levelToLoad = "LevelSelect";

    public void PlayGame()
    {
        Application.LoadLevel(2);
    }

    public void QuitGame()
    {        
        Application.Quit();
        //Debug.Log("Exiting");
    }

    public void MainMenu()
    {
        Application.LoadLevel(0);
    }
    
    public void HowToPlay()
    {
        Application.LoadLevel(6);
    }
}

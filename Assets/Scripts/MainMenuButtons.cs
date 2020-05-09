using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{

    public string levelToLoad = "MainLevel";

    public void PlayGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void QuitGame()
    {
        Debug.Log("Exiting");
        Application.Quit();
    }

    public void MainMenu()
    {
        Application.LoadLevel(0);
    }
}

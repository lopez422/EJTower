
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text roundsText;
    public string nextLevel;

    void OnEnable()
    {
    	roundsText.text = PlayerStats.Rounds.ToString();
    }

    public void Retry()
    {
    	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void Continue()
    {
        SceneManager.LoadScene(nextLevel);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    	Debug.Log("Go to MENU");
    }
}

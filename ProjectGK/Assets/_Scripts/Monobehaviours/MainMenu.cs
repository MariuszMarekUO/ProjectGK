using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenLeaderboard()
    {
        SceneManager.LoadScene("Leaderboard");
    }

    public void OpenMenu()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("sef");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }
}

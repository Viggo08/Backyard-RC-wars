using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("ViggoScene");
    }

    public void LoadGameScene()
    {
        //Name of scene with the game
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}

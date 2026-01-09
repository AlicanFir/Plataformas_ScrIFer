using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private int nextScene;
    

    public void StartGame()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }
}

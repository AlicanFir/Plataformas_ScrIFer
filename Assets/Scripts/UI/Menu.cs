using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private int nextScene;
    [SerializeField] private Vector3 spawnPositionLevel1;
    

    public void StartGame()
    {
        GameManager.instance.LoadNewLevel(nextScene, spawnPositionLevel1, Vector3.zero);
        Debug.Log(nextScene);
        
       // SceneManager.LoadScene(nextScene);
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

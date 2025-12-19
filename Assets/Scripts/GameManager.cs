using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //EL GAME MANAGER ES PARA TRANSPORTAR DATOS
    
    //estos datos son los que se van cargando de escena en escena:
    public Vector3 SavedPosition {get; set; }
    public Vector3 SavedRotation {get; private set; }
    //Patron Singleton:
        //instancia unica, no se destruye entre escenas, es accesible desde cualquier script
    public static GameManager instance;

    public float SavedScore { get; set; }
    public float SavedHealth { get; } = 100;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {Destroy(gameObject);}
    }

    public void LoadNewLevel(int levelIndex, Vector3 spawnPosition, Vector3 spawnRotation)
    {
        SavedPosition = spawnPosition;
        SavedRotation = spawnRotation;
        
        SceneManager.LoadScene(levelIndex);
    }
}

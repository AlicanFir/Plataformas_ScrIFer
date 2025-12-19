using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPortal : MonoBehaviour
{
    [SerializeField] private int targetSceneIndex;
    
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private Vector3 spawnRotation;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.LoadNewLevel(targetSceneIndex, spawnPosition, spawnRotation);
        }
    }
}

using System;
using UnityEngine;

public class EndCircleScript : MonoBehaviour
{
    [SerializeField] private GameObject endMenu;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0;
            endMenu.SetActive(true);
        }
    }
}

using System;
using UnityEngine;

public class MageDetector : MonoBehaviour
{
    private Mage mageScript;
    private void Awake()
    {
        mageScript = transform.root.GetComponent<Mage>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            mageScript.Target = other.gameObject;
            
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            mageScript.Target = null;
            mageScript.shooting = false;
        }
    }
}

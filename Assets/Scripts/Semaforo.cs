using System.Collections;
using UnityEngine;

public class Semaforo : MonoBehaviour
{
    private bool enEjecucucion = false;
    /*
    private void Update()
    {
        if (!enEjecucucion)
        {
            StartCoroutine(Funcionamiento());
        }
    }
    */
    private void Start()
    {
        StartCoroutine(Funcionamiento());
    }
    
    private IEnumerator Funcionamiento()
    {
        while (true) //comportamiento por siemre preno no explota
        {
            Debug.Log("Verde");
            yield return new WaitForSeconds(2f);
            Debug.Log("Amarillo");
            yield return new WaitForSeconds(2f);
            Debug.Log("Rojo");
            yield return new WaitForSeconds(2f);
        }

    }
}

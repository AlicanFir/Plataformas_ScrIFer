using System;
using System.Collections.Generic;
using UnityEngine;

public class PatrolSystem : MonoBehaviour
{
    [SerializeField] private Transform patrolPath; //la hacemos de tipo transform porque solo nos interesan las coordenadas.
    [SerializeField] private float patrolSpeed;

    private int currentIndex = 0;
    private List<Vector3> patrolPoints = new List<Vector3>();

    private void Awake()
    {
        foreach (Transform child in patrolPath) //el transform cuenta como una coleccion y te saca los hijos
        {
            patrolPoints.Add(child.position);
        }
        transform.eulerAngles = transform.position.x > patrolPoints[currentIndex].x ? new Vector3(0, 180, 0) : Vector3.zero;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentIndex], patrolSpeed * Time.deltaTime);
        if (transform.position == patrolPoints[currentIndex])
        {
            SetNewDestination();
        }
        
    }

    private void SetNewDestination()
    {
        currentIndex = (currentIndex + 1) % patrolPoints.Count;
        //% = operador modulo -- son las 23 + 2 == 1
        // patrol points = 2 si estamos en 1, y sumamos 1, damos la vuelta y vamos a 0.

        transform.eulerAngles = transform.position.x > patrolPoints[currentIndex].x ? new Vector3(0, 180, 0) : Vector3.zero; // mi objetivo esta a la izquierda
    }
}

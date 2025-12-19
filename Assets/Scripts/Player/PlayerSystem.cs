using System;
using UnityEngine;

public class PlayerSystem : MonoBehaviour
{
    protected Player main; //Mediador

    //Esto es heredado pero, debido a virtual, dejo la puerta abierta a poner mas cosas.
    protected virtual void Awake()
    {
        main = transform.root.GetComponent<Player>();
    }
}

using UnityEngine;
using System;

public class Player : MonoBehaviour, IDahable
{
    public event Action<float> seActualizaMovimiento; //notificacion, evento.
    //entre las flechas indico si el invoke puede pasar cosas
    
    

    public void ActualizaMovimiento(float hInput)
    {
        seActualizaMovimiento?.Invoke(hInput); // "?" null safety, si tienes suscriptores ps lo lanza si no no explota
    }

    public void TakeDamage(GameObject o, float damage)
    {
        throw new NotImplementedException();
    }
}

using System;
using UnityEngine;

public class PlayerStaminaSystem : PlayerSystem
{
    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        main.seActualizaMovimiento += ReciboNotificacion;
    }

    private void ReciboNotificacion(float value)
    {
        Debug.Log("Recibo Notificacion");
    }
}

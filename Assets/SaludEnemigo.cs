using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaludEnemigo : MonoBehaviour
{
    [SerializeField] int saludEnemigo;

    public void RecibirDaño()
    {
        if (saludEnemigo - 1 > 0)
        {
            saludEnemigo--;
        }
        else
        {
            //IMPLEMENTAR POOL
            ControlOleadas.Instancia.RegistrarMuerto();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("proyectil"))
        {
            RecibirDaño();
        }
    }
}

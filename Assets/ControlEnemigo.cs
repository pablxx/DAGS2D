using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemigo : MonoBehaviour
{
    [SerializeField] public Transform posicionObjetivo;
    [SerializeField] float velocidadMovimiento;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, posicionObjetivo.position, Time.deltaTime * velocidadMovimiento);
    }
}

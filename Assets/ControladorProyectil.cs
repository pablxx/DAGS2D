using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorProyectil : MonoBehaviour
{
    [SerializeField] Transform posicionEnemigo;
    [SerializeField] float velocidadProyectil;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (posicionEnemigo == null)
            return;

        transform.position = Vector2.MoveTowards(transform.position, posicionEnemigo.position, Time.deltaTime * velocidadProyectil);
    }

    public void CambiarObjetivo(Transform posicionNueva)
    {
        posicionEnemigo = posicionNueva;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemigo"))
        {
            PoolProyectiles.Instancia.DevolverProyectil(gameObject);
            //Destroy(gameObject);
        }
    }
}

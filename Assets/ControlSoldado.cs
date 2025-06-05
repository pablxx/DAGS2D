using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSoldado : MonoBehaviour
{
    [SerializeField] Transform posicionEnemigo;
    [SerializeField] float tiempoDisparo = 1.5f;
    [SerializeField] float tiempoTranscurrido = 0;
    //[SerializeField] GameObject proyectil;

    //[SerializeField] PoolProyectiles controlProyectiles;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemigo"))
        {
            posicionEnemigo = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemigo"))
        {
            posicionEnemigo = null;
        }
    }

    private void Update()
    {
        if (posicionEnemigo == null)
            return;

        if (tiempoDisparo > tiempoTranscurrido)
        {
            tiempoTranscurrido += Time.deltaTime;
        }
        else
        {
            //Este era el codigo inicial que instancia cada vez
            //ControladorProyectil proyectilNuevo = Instantiate(proyectil, transform.position, transform.rotation).GetComponent<ControladorProyectil>();
            //proyectilNuevo.CambiarObjetivo(posicionEnemigo);

           
            GameObject nuevoProyectil = PoolProyectiles.Instancia.ObtenerProyectil();
            nuevoProyectil.GetComponent<ControladorProyectil>().CambiarObjetivo(posicionEnemigo);
            nuevoProyectil.transform.position = transform.position;
            nuevoProyectil.SetActive(true);
            ControladorSonidos.Instancia.ReproducirSonido("proyectil");

            tiempoTranscurrido = 0;
        }
    }


}

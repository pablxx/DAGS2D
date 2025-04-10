using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaludSapo : MonoBehaviour
{
    [SerializeField] int cantidadInicialVidas;
    [SerializeField] int cantidadActualVidas;
    [SerializeField] Transform posicionReinicio;
    [SerializeField] ControlPlayer controlPlayer;
    [SerializeField] bool muerto = false;

    void Start()
    {
        controlPlayer = GetComponent<ControlPlayer>();
        cantidadActualVidas = cantidadInicialVidas;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //collision.transform.tag == "Auto"
        //collision.transform.tag.Equals("Auto")
        if (muerto)
            return;

        if (collider.transform.CompareTag("Auto"))
        {
            MatarSapo();
        }
    }

    void MatarSapo()
    {
        Debug.Log("Sapo muerto :(");
        muerto = true;
        controlPlayer.BloquearSapo();

        if (cantidadActualVidas > 0)
        {
            cantidadActualVidas--;
            Debug.Log("TENGO " + cantidadActualVidas + " VIDAS");
            Invoke("ReposicionarSapo", 4f);
        }
        else
        {
            //GameOver
        }
    }

    void ReposicionarSapo()
    {
        muerto = false;
        transform.position = posicionReinicio.position;
        controlPlayer.DesbloquearSapo();
    }


    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    //collision.transform.tag == "Auto"
    //    //collision.transform.tag.Equals("Auto")
    //    if (collision.transform.CompareTag("Auto"))
    //    {
    //        Debug.Log("Sapo muerto :(");
    //    }
    //}
}

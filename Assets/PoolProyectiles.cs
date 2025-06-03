using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolProyectiles : MonoBehaviour
{
    [SerializeField] GameObject objetoProyectil;
    [SerializeField] List<GameObject> listaProyectiles;
    //[SerializeField] List<GameObject> listaProyectiles;
    [SerializeField] int cantidadMaximaObjetosPool;

    public static PoolProyectiles Instancia;


    void Awake()
    {
        if (Instancia != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instancia = this;
        }

        IniciarLista();
    }

    void IniciarLista()
    {
        for (int i = 0; i < cantidadMaximaObjetosPool; i++)
        {
            listaProyectiles.Add(Instantiate(objetoProyectil, transform.position, transform.rotation));
        }
    }

    public GameObject ObtenerProyectil()
    {
        GameObject nuevoProyectil = null;
        foreach (var proyectil in listaProyectiles)
        {
            if (proyectil.gameObject.activeInHierarchy == false)
            {
                nuevoProyectil = proyectil;
                break;
            }
        }


        return nuevoProyectil;
    }

    public void DevolverProyectil(GameObject objetoDevuelto)
    {
        objetoDevuelto.transform.position = transform.position;
        objetoDevuelto.SetActive(false);
    }
}

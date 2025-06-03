using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PoolingInterfaz : MonoBehaviour
{
    IObjectPool<GameObject> piscina;
    // Start is called before the first frame update
    void Start()
    {
        piscina = new ObjectPool<GameObject>(CrearObjeto, ObtenerObjeto, DevolverObjeto, DestruirObjeto, true, 10, 40);
    }

    GameObject CrearObjeto()
    {
        return new GameObject();
    }

    void ObtenerObjeto(GameObject objeto)
    {

    }

    void DevolverObjeto(GameObject objeto)
    {

    }

    void DestruirObjeto(GameObject objeto) { 
    
    }
}

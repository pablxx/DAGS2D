//SECCION DE IMPORTACIONES
//espacios de nombres - namespaces
using UnityEngine;

public class CicloDeVida : MonoBehaviour
{
    // Start is called before the first frame update
    //void significa "vacio", es funcion no devuelve, ningun valor
    //private significa privado, pero si no dice nada antes, la funcion
    //es por defecto, privada -> private

    void Awake()
    {
        //Depurar, limpiar, eliminar, bugs
        Debug.Log("Estoy en Awake");
    }

    private void OnEnable()
    {
        Debug.Log("Estoy en OnEnable");
    }

    void Start()
    {
        Debug.Log("Estoy en Start");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Estoy en Update");
    }

    private void FixedUpdate()
    {
        //Esta clase imprime mensajes, con el metodo Log
        Debug.Log("Estoy en FixedUpdate");
    }

    private void LateUpdate()
    {
        Debug.Log("Estoy en LateUpdate");
    }

    private void OnDisable()
    {
        Debug.Log("Estoy en OnDisable");
    }

    private void OnDestroy()
    {
        Debug.Log("Estoy en OnDestroy");
    }

    //int devuelve un numero, entero
    int SumarDosEnteros(int a, int b)
    {
        int resultado = a + b;
        return resultado;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlOleadas : MonoBehaviour
{
    [SerializeField]
    List<GameObject> enemigosOleada;

    [SerializeField]
    int cantidadEnemigos;

    [SerializeField]
    int cantidadEnemigosInicial;

    [SerializeField]
    int cantidadMuertos;

    [SerializeField]
    float frecuenciaEnemigos;

    [SerializeField]
    GameObject objetoEnemigo;

    [SerializeField]
    Transform posicionBase;

    WaitForSeconds esperaEnemigos;

    public static ControlOleadas Instancia;

    private void Awake()
    {
        if (Instancia != null)
            Destroy(gameObject);
        else
            Instancia = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        cantidadEnemigosInicial = cantidadEnemigos;
        esperaEnemigos = new WaitForSeconds(frecuenciaEnemigos);

        StartCoroutine(InstanciarEnemigos());
    }

    public void RegistrarMuerto()
    {
        cantidadMuertos++;
        VerificarGameOver();
    }

    void VerificarGameOver() { 
        if (cantidadMuertos == cantidadEnemigosInicial)
        {
            ControlLogica.Instancia.GameOver();
        }
    }

    IEnumerator InstanciarEnemigos()
	{
        while (cantidadEnemigos > 0)
        {
            yield return esperaEnemigos;
            ControlEnemigo nuevoEnemigo = Instantiate(objetoEnemigo, transform.position, transform.rotation)
                                                      .GetComponent<ControlEnemigo>();

            nuevoEnemigo.posicionObjetivo = posicionBase;
            enemigosOleada.Add(nuevoEnemigo.gameObject);

            cantidadEnemigos--;
        }
	}
}

//COMENTARIO NOMAS
//public class InfoOleadas
//{
//    public string nombreOleada;
//    public int cantidadEnemigos;
//    public GameObject tipoEnemigo;
//    public enum categoriaEnemigo {Volador, Acuatico, Terrestre}
//}

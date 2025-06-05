using System.Collections.Generic;
using UnityEngine;

public class ControladorSonidos : MonoBehaviour
{
    public static ControladorSonidos Instancia;
    public List<SonidosJuego> misSonidos;
    
    [Range(0.7f, 1.3f)]
    public float pitchMinimo;

    [Range(0.7f, 1.3f)]
    public float pitchMaximo;

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

        IniciarControlador();
    }

    void IniciarControlador()
    {
        foreach (var sonido in misSonidos)
        {
            AudioSource nuevoParlante = gameObject.AddComponent<AudioSource>();
            nuevoParlante.clip = sonido.clipSonido;
            sonido.parlanteSonido = nuevoParlante;
        }
    }

    public void ReproducirSonido(string sonidoObjetivo)
    {
        foreach (var sonido in misSonidos)
        {
            if (sonido.nombreSonido.Equals(sonidoObjetivo))
            {
                sonido.parlanteSonido.pitch = Random.Range(pitchMinimo, pitchMaximo);
                sonido.parlanteSonido.Play();
                break;
            }
            else if (!sonido.nombreSonido.Equals(sonidoObjetivo))
            {
                continue;
            }
            else
            {
                Debug.Log("No existe ese sonido :(");
            }
        }
    }
}

[System.Serializable]
public class SonidosJuego
{
    public string nombreSonido;
    public AudioClip clipSonido;
    public AudioSource parlanteSonido;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCarril : MonoBehaviour
{
    [SerializeField] GameObject obstaculoPrefab;
    [SerializeField] Transform posicionObjetivo;

    [SerializeField] float velocidadObjetivo;
    [SerializeField] float tiempoMax, tiempoMin;

    void Start()
    {
        StartCoroutine(InstanciarObstaculos());
    }

    IEnumerator InstanciarObstaculos()
    {
        while(true)
        {
            GameObject nuevoObstaculo = Instantiate(obstaculoPrefab, transform.position, transform.rotation);
            nuevoObstaculo.GetComponent<ControlObstaculo>().ActualizarObstaculo(velocidadObjetivo, posicionObjetivo);

            yield return new WaitForSeconds(Random.Range(tiempoMin, tiempoMax));
        }
    }
}

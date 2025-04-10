using UnityEngine;

public class ControlObstaculo : MonoBehaviour
{
    //se declara entero, por que...
    [SerializeField] float velocidadMovimiento;
    [SerializeField] Transform objetivoObstaculo;
    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, objetivoObstaculo.position, velocidadMovimiento * Time.deltaTime);
    }

    public void ActualizarObstaculo(float velocidad, Transform nuevoObjetivo)
    {
        velocidadMovimiento = velocidad;
        objetivoObstaculo = nuevoObjetivo;

    }
}

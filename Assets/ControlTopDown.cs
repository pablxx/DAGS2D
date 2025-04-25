using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTopDown : MonoBehaviour
{
    [SerializeField] Animator miAnimador;
    [SerializeField] Rigidbody2D miCuerpo;
    [SerializeField] bool corriendo;
    [SerializeField] Vector2 direccionEntrada;
    //[SerializeField] Vector2 ultimaDireccion;

    void Start()
    {
        miCuerpo = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        LeerTeclado();
        Mover();
        Animar();
    }

    void LeerTeclado()
    {
        direccionEntrada = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Debug.Log($"Direccion en X {direccionEntrada.x} --- Direccion en Y {direccionEntrada.y}");
    }

    void Mover()
    {
        //Movemos al personaje
        if (direccionEntrada.magnitude >= 0.15f)
            miCuerpo.velocity = new Vector2(direccionEntrada.x, direccionEntrada.y);
        else
            miCuerpo.velocity = Vector2.zero;
        

        if (miCuerpo.velocity.magnitude != 0)
            corriendo = true;
        else
            corriendo = false;
    }



    void Animar()
    {
        //Actualizando el animador
        //Actualizar el estado de corriendo
        miAnimador.SetBool("corriendo", corriendo);

        //Actualizar las direcciones
        miAnimador.SetFloat("dirX", direccionEntrada.x);
        miAnimador.SetFloat("dirY", direccionEntrada.y);
        //Debug.Log("Direccion en X " + direccionEntrada.x + " --- Direccion en Y " + direccionEntrada.x );
    }
}

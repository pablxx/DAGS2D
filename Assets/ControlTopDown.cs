using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTopDown : MonoBehaviour
{
    [SerializeField] Animator miAnimador;
    [SerializeField] Rigidbody2D miCuerpo;
    [SerializeField] bool corriendo;
    [SerializeField] Vector2 direccionEntrada;
    [SerializeField] bool velocidadExtra;
    [SerializeField] float incrementoVelocidad;
    [SerializeField] float velocidad;
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
        
        velocidadExtra = Input.GetKey(KeyCode.LeftShift) ? true : false;
        
        //if (Input.GetKey(KeyCode.LeftShift))
        //{
        //    velocidadExtra = true;
        //}
        //else
        //{
        //    velocidadExtra = false;
        //}

        Debug.Log($"Direccion en X {direccionEntrada.x} --- Direccion en Y {direccionEntrada.y}");
    }

    void Mover()
    {
        //Movemos al personaje
        if (direccionEntrada.magnitude >= 0.15f)
            miCuerpo.velocity = new Vector2(direccionEntrada.x * incrementoVelocidad * velocidad, 
                                            direccionEntrada.y * incrementoVelocidad * velocidad);
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

        incrementoVelocidad = velocidadExtra ? 2 : 1;

        //if (velocidadExtra == true)
        //{
        //    incrementoVelocidad = 2;
        //}
        //else
        //{
        //    incrementoVelocidad = 1;
        //}

        //Actualizar las direcciones
        miAnimador.SetFloat("dirX", direccionEntrada.x * incrementoVelocidad);
        miAnimador.SetFloat("dirY", direccionEntrada.y * incrementoVelocidad);
        //Debug.Log("Direccion en X " + direccionEntrada.x + " --- Direccion en Y " + direccionEntrada.x );
    }
}

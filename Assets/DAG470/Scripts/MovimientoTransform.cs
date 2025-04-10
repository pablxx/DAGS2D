using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoTransform : MonoBehaviour
{
    //Seccion variables
    //[SerializeField]
    //private Transform elTransformDeMiPersonaje;
    //[SerializeField]
    //private Vector3 direccionMovimiento;
    [SerializeField]
    private float velocidadMovimiento;

    [SerializeField]
    private Rigidbody2D miCuerpo;
    //private Vector3 direccionMovimiento = new Vector3(0.075f, 0, 0); creando un valor por defecto

    [SerializeField]
    private Transform puntoObjetivo;

    [SerializeField]
    private float fuerzaSalto;

    // Start is called before the first frame update
    private void Start()
    {
        //Debug.Log(elTransformDeMiPersonaje.position);
        //Debug.Log("La posicion en X es " + elTransformDeMiPersonaje.position.x);
        //elTransformDeMiPersonaje.position = new Vector2(0, -2);
        miCuerpo = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        //transform.position = new Vector2(transform.position.x + 0.075f, transform.position.y);
        //transform.Translate(direccionMovimiento);
        Debug.Log(Time.deltaTime);

        
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    transform.position = new Vector2(transform.position.x + 0.75f, transform.position.y);
        //}
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    transform.position = new Vector2(transform.position.x, transform.position.y + 0.75f);
        //}
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    transform.position = new Vector2(transform.position.x - 0.75f, transform.position.y);
        //}
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    transform.position = new Vector2(transform.position.x, transform.position.y - 0.75f);
        //}

        //GETAXIS, devuelve, un numero, entre -1.0 y 1.0
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.position = new Vector2(transform.position.x + (velocidadMovimiento * Time.deltaTime * Input.GetAxis("Horizontal")), transform.position.y);
        }

        if (Input.GetButtonDown("Jump") && miCuerpo.velocity.y == 0)
        {
            miCuerpo.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }

        //transform.position = Vector2.MoveTowards(transform.position, puntoObjetivo.position, velocidadMovimiento * Time.deltaTime);


    }

}

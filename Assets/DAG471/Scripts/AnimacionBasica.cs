using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionBasica : MonoBehaviour
{
    //creamos una variable de tipo Animator privada
    //Animator miAnimador;

    // Para que la variable sea visible en el editor hay dos formas, una que no es buena y otra que si lo es
    // LA INADECUADA: hacer la variable publica en caso de que la variable no afecte a las mecanicas directamente (balas,salud,recompensa)
    // public Animator miAnimador;


    // LA ADECUADA: hacer la variable privada y serializable
    /// <summary>
    /// Esto no publica la variable , pero si la hace editable en unity
    /// </summary>
    [SerializeField] Animator miAnimador; //variable no inicializada por lo tanto esta vacio y da error
    [SerializeField] float velocidadMovimiento;
    [SerializeField] bool estido;

    // Start is called before the first frame update
    void Start()
    {
        //inicializamos la variable miAnimador para que al iniciar muera el personaje
        //miAnimador.SetBool("estaMuerto", true); //sus dos parametros son el nombre de la variable y el valor que se le asigna

    }

    // INPUT -> Lee el teclado, pero es un sistema antiguo
    void Update()
    {
        float entradaEnX = Input.GetAxis("Horizontal");

        //si pulsamos una tecla matamos al personaje
        if (Input.GetKeyDown(KeyCode.Q)) //es una condicion por lo cual debe leerse en una estructura condicional "if"
        {
            miAnimador.SetBool("muerto", true); //lo que va en comillas es el nombre exacto de la variable del animador, importante
            estido = true;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            miAnimador.SetTrigger("herido");
        }


        if (entradaEnX != 0 && estido == false)
        {
            
            miAnimador.SetBool("caminando", true);
            transform.position = new Vector2(transform.position.x + velocidadMovimiento * Time.deltaTime * entradaEnX,
                                             transform.position.y);
        }
        else
        {
            miAnimador.SetBool("caminando", false);
        }
    }
}

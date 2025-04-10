using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChicaController : MonoBehaviour
{

    [SerializeField] Animator miAnimador; //variable no inicializada por lo tanto esta vacio y da error
    [SerializeField] float velocidadMovimiento;
    [SerializeField] bool estido;
    [SerializeField] bool disparando;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float entradaEnX = Input.GetAxis("Horizontal");


        if (entradaEnX != 0 && estido == false)
        {
            miAnimador.SetBool("caminando", true);

            transform.position = new Vector2(transform.position.x + velocidadMovimiento * Time.deltaTime * entradaEnX,
                                             transform.position.y);
            if (transform.localScale.x < 0 && entradaEnX > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
            else if(transform.localScale.x > 0 && entradaEnX < 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
        }
        else
        {
            miAnimador.SetBool("caminando", false);
        }

        if (Input.GetKeyDown(KeyCode.E)) //es una condicion por lo cual debe leerse en una estructura condicional "if"
        {
            miAnimador.SetTrigger("disparar"); //lo que va en comillas es el nombre exacto de la variable del animador, importante
            disparando = true;
        }


    }
}

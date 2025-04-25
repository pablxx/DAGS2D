using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoverAnimadoFisica : MonoBehaviour
{
    //creamos variables que necesitamos para movimeinto
    public float velocidad;
    public float fuerzaSalto;
    public Rigidbody2D miCuerpo;
    public Animator miAnimador;
    public Transform piesPersonaje;
    public bool pisando; //true o false

    public LayerMask capaPiso;

    public bool muerto = false;

    // Start is called before the first frame update
    
    void Start()
    {
        //llamamos al rigidbody2D en la variable mi cuerpo
        miCuerpo = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //la muerte se verifica al inicio porque una vez nuerto no deberia poder moverme ni nada
        if (Input.GetKeyDown(KeyCode.K))
        {
            muerto = true;
            miAnimador.SetBool("muerta", true);
        }

        if (muerto == true)
        {
            return; //return esta cortando la ejecucion del update si no tiene ningun valor a su derecha.
                    //return es para salirse de la funcion. Si tuviera un valor, enviaria algun valor.
        }
            


        float entradaX = Input.GetAxis("Horizontal");
        miAnimador.SetFloat("velY", miCuerpo.velocity.y);
        //cuando usamos fisica debemos tener cuidado, lo que estamos haciendo es agregar una fuerza
        //que dice que le damos una fuerza que vamos agregando y no dejamos de agregar,
        // si mantenemos la fuerza presionando una tecla sostenida algun rato se nos dispara
        // por lo que debemos poner otra condicion mas
        //debemos verificar que por un lado este presionando tecla en X y no sobrepase el top de la velocidad
        if (entradaX != 0)
        {
            //para caminar, creamos un vector que lo mueva en X por lo que solo tendremos velocidad para X y 0 para Y
            // ForceMode2D es para darle una fuerza del tipo fuerza Force porque no es un empujon si no una fuerza que lo mueve.
            //miCuerpo.AddForce(new Vector2(velocidad, 0f), ForceMode2D.Force);


            //usaremos este para simplificar
            //la velocidad en y no puede ser 0 porque quedaria suspendido en el aire.
            //miCuerpo.velocity.y dice cualquiera que sea mi velocidad en y está bien.
            //por que no usamos timedeltatime sin la necesidad de volar.
            miCuerpo.velocity = new Vector2(velocidad * entradaX, miCuerpo.velocity.y);
            //porque la frecuencia de actualizacion de la fisa no es continuo el rigidbody 
            //la fisica nunca es tan rapida como los FPS
            //cuando ponemos velocidads, con fuerzas, l motor fisico no es tan frecuente, es lento para que el juego no reviente.


            //para el animador
            //miAnimador.SetFloat("velX", miCuerpo.velocity.x);
            miAnimador.SetFloat("velX", Mathf.Abs(miCuerpo.velocity.x)); // con valor absoluto

            /*
            if (transform.localScale.x > 0 && Input.GetAxis("Horizontal") < 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1,
                                                    transform.localScale.y, transform.localScale.z);
            }
            else if (transform.localScale.x < 0 && Input.GetAxis("Horizontal") > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1,
                                                transform.localScale.y, transform.localScale.z);
            }

            */

            if((transform.localScale.x < 0 && entradaX > 0) || (transform.localScale.x > 0 && entradaX < 0))
            {
                transform.localScale = new Vector3(transform.localScale.x * -1f, //aqui le decimos que multiplicamos la escala por -1
                                                    transform.localScale.y,
                                                    transform.localScale.z);

            }

        }
        else if (entradaX == 0)
        {
            miCuerpo.velocity = new Vector2(0, miCuerpo.velocity.y);
            miAnimador.SetFloat("velX", miCuerpo.velocity.x);
            //miAnimador.SetFloat("velX", miCuerpo.velocity.x);
            //poner mi animador a 0
        }

        //Salto
        if (Input.GetButtonDown("Jump") && pisando == true)
        {
            miCuerpo.AddForce(new Vector2(0f, fuerzaSalto), ForceMode2D.Impulse);
        }

        //es otra forma de probar nuestro codigo, una forma de depurar, debug.log mensajes
        //este gizmos que son dibujos.
        if (Input.GetButtonDown("Fire1"))
        {
            miAnimador.SetTrigger("disparo");   
        }
        if (Input.GetButtonDown("Fire3"))
        {
            miAnimador.SetTrigger("golpe");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            miAnimador.SetTrigger("deslizar");
        }
    }


    //es un update fijo, no es segun los FPS no necesitamos multiplicar por el deltatime por lo que podemos usarlo para fisicas
    //hace que sea un poco mas ligero por ser mas lento
    /*
     la clase vector2 tuene up,down,left,right,zero,identidad. Identidad es 1.1 y vector zero es 0.0
    tener cuidado de la rotacion del personaje porque si esta patas arriba con rotacion de 180 down se va arriba
     */

    //creamos un nuevo rayo y le hacemnos salir delos pies del pj hacia abajo
    //nuestro primer problema es que el rayo esta infinito pro lo que debemos decirle en que capa esta el piso y cual es la distancia qu debe detectar el piso.
    
    
    //phiscic 2d racaste siginifca que lanza el rayito hasta buscar una colicion ida y vuelta.
    private void FixedUpdate()
    {
        RaycastHit2D miRayo = Physics2D.Raycast(piesPersonaje.position, Vector2.down, 0.5f, capaPiso);
        
        if(miRayo.collider != null)
        {
            pisando = true;
            miAnimador.SetBool("Pisando", pisando); // con comillas es el nombre de la variable del animador, sin comillas es la variable de aqui adentro
        }
        else
        {
            pisando = false;
            miAnimador.SetBool("Pisando", pisando);
        }
    }





    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(piesPersonaje.position,Vector2.down);
    }
}

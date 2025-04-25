using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AnimacionSprites : MonoBehaviour
{
    public Animator miAnimador; //guardamos una copia de animator en codigo.
    public float velocidad = 0.035f;
    public bool atacando;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float entradaX = Input.GetAxis("Horizontal");
        if (entradaX != 0 && atacando == false) //dentro de este if tendremos 3 valores (0,1, -1 y decimales entre 0 y 1)
        {
            miAnimador.SetBool("correr", true);
            transform.position = new Vector3(transform.position.x + velocidad * Input.GetAxis("Horizontal"),
                                            transform.position.y,
                                            transform.position.z);
            if (transform.localScale.x > 0 && Input.GetAxis("Horizontal") < 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1,
                                                    transform.localScale.y, transform.localScale.z);
            }
            else if(transform.localScale.x < 0 && Input.GetAxis("Horizontal") > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1,
                                                transform.localScale.y, transform.localScale.z);
            }
        }
        else if(entradaX == 0)
        {
            miAnimador.SetBool("correr", false);
        }

        //miAnimador es la variable contenedora, SetBool es que seteamos un bool porq
        if (Input.GetButtonDown("Fire1") && atacando == false && entradaX == 0)
        {
            atacando = true;
            miAnimador.SetTrigger("atacar");
            StartCoroutine(CancelarAtaque()); //corrutina
        }
        
    }

    //Corrutina
    IEnumerator CancelarAtaque()
    {
        yield return new WaitForSeconds(0.8f);
        atacando = false;
    }
}

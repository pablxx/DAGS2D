using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColicionATK : MonoBehaviour
{
    //Animator animadorEventos; //necesitamos una variable animador para llamar. Animator es el tipo de dato.
    // Start is called before the first frame update
    //public GameObject colision;
    public BoxCollider2D colision; //solo queremos el box colider no todo el objeto/personaje.
    void Start()
    {
        //animadorEventos = GetComponent<Animator>(); //si no hay nada delante de GetComponente es de nosotros mismos. Animator tipo de dato
        colision = GetComponent<BoxCollider2D>();//el tipo de dato es boxcolider por eso lo traemos aqui
    }

    public void ActivarColisiones() //siempre publico
    {
        //colision.SetActive(true);//set active solo en game objects porque quiere decir que activaremos un game object como tiqueando el botn de arriba de activo
        colision.enabled = true;
    }
    public void DesactivarColisiones()
    {
        colision.enabled = false;
    }
}

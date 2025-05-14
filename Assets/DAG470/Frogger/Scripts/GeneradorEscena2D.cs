using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEscena2D : MonoBehaviour
{
    [SerializeField] GameObject objetoEscena;
    //[SerializeField] List<GameObject> objetosEscena;
    [SerializeField] Transform posicionObjeto;
    [SerializeField] SpriteRenderer miSprite;
    [SerializeField] List<GameObject> objetosEnEscena;


    void Start()
    {
        StartCoroutine(GenerarEscena());    
    }

    IEnumerator GenerarEscena()
    {
        while (true)
        {
            objetosEnEscena.Add(Instantiate(objetoEscena, posicionObjeto.position, posicionObjeto.rotation));
            posicionObjeto.position = new Vector2(posicionObjeto.position.x + (miSprite.bounds.extents.x * 2),
                                                  posicionObjeto.position.y);
            DestruirMasAntiguo();
            yield return new WaitForSeconds(2f);
        }
    }

    void DestruirMasAntiguo()
    {
        Destroy(objetosEnEscena[0], 8f);
        objetosEnEscena.RemoveAt(0);
    }
}

using UnityEngine;

public class ControladorCholita : MonoBehaviour
{
    [SerializeField] Animator elAnimador;
    [SerializeField] bool caminando;
    [SerializeField] bool enPiso;
    [SerializeField] Rigidbody2D cuerpito;
    [SerializeField] float velocidad;
    [SerializeField] float fuerzaSalto;

    void Start()
    {
        cuerpito = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float entradaJugador = Input.GetAxis("Horizontal");
        elAnimador.SetBool("caminata", caminando);
        elAnimador.SetFloat("velY", cuerpito.velocity.y);
        elAnimador.SetBool("enPiso", enPiso);

        //Este bloque rota al personaje
        if (transform.localScale.x > 0 && entradaJugador < 0)
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
        else if(transform.localScale.x < 0 && entradaJugador > 0)
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);

        
        if (entradaJugador != 0)
        {
            caminando = true;
            cuerpito.velocity = new Vector2(velocidad * entradaJugador, cuerpito.velocity.y);
        }
        else
        {
            caminando = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            cuerpito.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("piso"))
        {
            enPiso = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("piso"))
        {
            enPiso = false;
        }
    }
}

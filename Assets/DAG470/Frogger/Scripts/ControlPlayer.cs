
using UnityEngine;

public class ControlPlayer : MonoBehaviour
{
    [SerializeField] float distanciaSalto;
    [SerializeField] bool puedoMoverme;

    void Update()
    {
        if (!puedoMoverme)
            return;
        

        if (Input.GetKeyDown(KeyCode.A))
            transform.position = new Vector2(transform.position.x - distanciaSalto, transform.position.y);
        
        if (Input.GetKeyDown(KeyCode.S))
            transform.position = new Vector2(transform.position.x, transform.position.y - distanciaSalto);
        
        if (Input.GetKeyDown(KeyCode.D))
            transform.position = new Vector2(transform.position.x + distanciaSalto, transform.position.y);
        
        if (Input.GetKeyDown(KeyCode.W))
            transform.position = new Vector2(transform.position.x, transform.position.y + distanciaSalto);
    }

    public void BloquearSapo()
    {
        puedoMoverme = false;
    }

    public void DesbloquearSapo()
    {
        puedoMoverme = true;
    }

    //public void ActualizarMovimiento(bool estadoObjetivo)
    //{
    //    puedoMoverme = estadoObjetivo;
    //    puedoMoverme = !puedoMoverme;  
    //}
}

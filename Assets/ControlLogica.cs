using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLogica : MonoBehaviour
{
    enum EstadosJuego { EnCurso, GameOver, EnPausa};
    public static ControlLogica Instancia;

    private void Awake()
    {
        if (Instancia != null)
            Destroy(gameObject);
        else
            Instancia = this;
    }

    

    public void GameOver()
    {
        //COntrola la logica del juego
        ControlIU.Instancia.ActivarPanelGameOver();
        PausarJuego();
    }

    public void PausarJuego()
    {
        Time.timeScale = 0;
    }

    public void ReanudarJuego()
    {
        Time.timeScale = 1;
    }
}

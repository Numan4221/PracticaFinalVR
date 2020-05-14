using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfazSubirCanal : InterfazBase
{
    public ReproductorVideo reproductor;
    public MostrarCanal mostrador;
    // Start is called before the first frame update
    override
    protected void Start()
    {
        tiempoEsperar = 0.4f;
    }

    override
   public void actuar()
    {
        acumulador += Time.deltaTime;
        pulsado = true;

        if (acumulador > tiempoAcumulador)
        {
            if (tiempoActual <= 0)
            {
                tiempoActual = base.tiempoEsperar;
                reproductor.sigCanal();
                mostrador.actualizarCanal();

            }
            acumulador = tiempoAcumulador / 3;
        }

    }


}

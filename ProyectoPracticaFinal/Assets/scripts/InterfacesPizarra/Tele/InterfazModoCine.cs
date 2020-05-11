using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfazModoCine : InterfazBase
{
    public ReproductorVideo reproductor;

    override
    public void actuar()
    {
        if (tiempoActual <= 0)
        {
            tiempoActual = base.tiempoEsperar;
            StartCoroutine("activarCine");

        }
    }


    IEnumerator activarCine()
    {
        bool activado = false;

        while (!activado)
        {
            reproductor.ponerCine();
            activado = true;
            yield return new WaitForSecondsRealtime(base.tiempoEsperar);
        }

    }

}

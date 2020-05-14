using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfazDecoracion : InterfazBase
{
    public ControlPizarra controlPizarra;

    override
        public void actuar()
    {

        acumulador += Time.deltaTime;
        pulsado = true;

        if (acumulador > tiempoAcumulador)
        {
            if (tiempoActual <= 0)
            {
                tiempoActual = tiempoEsperar;
                StartCoroutine("llamarPizarra");

            }
            acumulador = 0;
        }

    }


    IEnumerator llamarPizarra()
    {
        bool activado = false;

        while (!activado)
        {
            activado = true;
            yield return new WaitForSecondsRealtime(tiempoEsperar);
        }

        controlPizarra.gestionarEntrada(ControlPizarra.comandos.Decoracion);

    }
}

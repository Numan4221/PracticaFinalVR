using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfazNota : InterfazBase
{
    public ControlPizarra controlPizarra;

    override
    public void actuar()
    {
        if (tiempoActual <= 0)
        {
            tiempoActual = tiempoEsperar;
            StartCoroutine("llamarPizarra");

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

        controlPizarra.gestionarEntrada(ControlPizarra.comandos.Musica);



    }



}

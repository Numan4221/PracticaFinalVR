using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BajarVolumenMusica : InterfazBase
{
     
    public MostrarVolumen mostrador;
    public Speakers controladorAltavocez;

    void Start()
    {
        tiempoEsperar = 0.2f;
    }

    override
    public void actuar()
    {
        if (tiempoActual <= 0)
        {
            tiempoActual = base.tiempoEsperar;
            StartCoroutine("bajarVol");

        }
    }


    IEnumerator bajarVol()
    {
        bool activado = false;

        while (!activado)
        {
            controladorAltavocez.bajarVolumen();
            activado = true;
            yield return new WaitForSecondsRealtime(base.tiempoEsperar);
        }

    }

}

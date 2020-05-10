using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubirVolumenMusica : InterfazBase
{
     
    public MostrarVolumen mostrador;
    public Speakers controladorAltavocez;
    // Start is called before the first frame update
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
            StartCoroutine("subirVol");

        }
    }


    IEnumerator subirVol()
    {
        bool activado = false;

        while (!activado)
        {
            controladorAltavocez.subirVolumen();
            activado = true;
            yield return new WaitForSecondsRealtime(base.tiempoEsperar);
        }

    }


}

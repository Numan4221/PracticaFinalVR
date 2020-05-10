using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interfaz : InterfazBase
{
    public ObjetoControlable miObjeto;

    override
    public void actuar()
    {
        if(tiempoActual <= 0)
        {
            if (encendido)
            {
                if(miObjeto != null)
                {
                    miObjeto.apagar();
                }

                encendido = false;
            } else
            {
                if (miObjeto != null)
                {
                    miObjeto.encender();
                }
                encendido = true;
            }
            tiempoActual = tiempoEsperar;
        }

    }


}

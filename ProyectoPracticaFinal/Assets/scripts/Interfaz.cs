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
            if (miObjeto.encendido)
            {
                if(miObjeto != null)
                {
                    miObjeto.apagar();
                }

            } else
            {
                if (miObjeto != null)
                {
                    miObjeto.encender();
                }
            }
            tiempoActual = tiempoEsperar;
        }

    }


}

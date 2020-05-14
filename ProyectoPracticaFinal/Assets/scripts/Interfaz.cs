using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interfaz : InterfazBase
{
    public ObjetoControlable miObjeto;


    override
    protected void Update()
    {
        if (tiempoActual > 0)
        {
            tiempoActual -= Time.deltaTime;
        }
    }

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
                    this.GetComponent<MeshRenderer>().material = interfazSinActivar;
                }

            } else
            {
                if (miObjeto != null)
                {
                    miObjeto.encender();
                    this.GetComponent<MeshRenderer>().material = interfazActivada;
                }
            }
            tiempoActual = tiempoEsperar;
        }

    }


}

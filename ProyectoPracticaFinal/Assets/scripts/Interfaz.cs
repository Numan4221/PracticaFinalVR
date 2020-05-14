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
        if (!pulsado && acumulador > 0)
        {
            acumulador -= Time.deltaTime;
        }
        if (pulsado)
        {
            pulsado = false;
        }
    }

    override
    public void actuar()
    {
        acumulador += Time.deltaTime;
        pulsado = true;

        if(acumulador > tiempoAcumulador)
        {
            metodoReal();
            acumulador = 0;
        }

    }

    public void metodoReal()
    {
        if (tiempoActual <= 0)
        {
            if (miObjeto.encendido)
            {
                if (miObjeto != null)
                {
                    miObjeto.apagar();
                    this.GetComponent<MeshRenderer>().material = interfazSinActivar;
                }

            }
            else
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

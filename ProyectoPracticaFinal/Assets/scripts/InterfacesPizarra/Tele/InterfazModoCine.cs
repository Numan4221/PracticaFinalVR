using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfazModoCine : InterfazBase
{
    public ReproductorVideo reproductor;

    public bool activadoCine;

    protected void Start()
    {
        tiempoActual = 0;
        activadoCine = false;
        if (activadoCine)
        {
            this.GetComponent<MeshRenderer>().material = interfazActivada;
        }
        else
        {
            this.GetComponent<MeshRenderer>().material = interfazSinActivar;
        }

    }

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

        if (acumulador > tiempoAcumulador)
        {
            if (tiempoActual <= 0)
            {
                tiempoActual = base.tiempoEsperar;
                activarCine();

            }
            acumulador = 0;
        }

    }


    void activarCine()
    {
        if (activadoCine)
        {
            reproductor.ponerCine();
            this.GetComponent<MeshRenderer>().material = interfazSinActivar;
            activadoCine = false;
        } else
        {
            reproductor.ponerCine();
            this.GetComponent<MeshRenderer>().material = interfazActivada;
            activadoCine = true;
        }

        tiempoActual = tiempoEsperar;

    }

}

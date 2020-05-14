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
    }


    override
    public void actuar()
    {
        if (tiempoActual <= 0)
        {
            tiempoActual = base.tiempoEsperar;
            activarCine();

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

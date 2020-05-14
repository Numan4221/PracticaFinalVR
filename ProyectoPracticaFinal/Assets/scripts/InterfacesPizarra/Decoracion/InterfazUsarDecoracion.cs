using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfazUsarDecoracion : InterfazBase
{
    public GetsorDecorador gestor;
    public bool activado = false;
    public List<InterfazUsarDecoracion> otrasInterfaces;
    public int num;

    override
     protected void Start()
    {
        tiempoActual = 0;
        if(num == 0)
        {
            activado = true;
        }
        if (activado)
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
                tiempoActual = tiempoEsperar;
                cambiarDecoracion();
                activado = true;
                this.GetComponent<MeshRenderer>().material = interfazActivada;

            }
            acumulador = 0;
        }


    }

    public void invalidar()
    {
        this.GetComponent<MeshRenderer>().material = interfazSinActivar;
        activado = false;
    }

    void cambiarDecoracion()
    {
        gestor.asignarModeloDecorativo(num);
        foreach(InterfazUsarDecoracion inter in otrasInterfaces)
        {
            inter.invalidar();
        }


    }
}

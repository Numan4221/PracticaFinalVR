using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaAleatoria : InterfazBase
{

    public Speakers controladorAltavoces;
    public List<MeshRenderer> mallas;
    bool aleatorio = false;


    override
    protected void Start()
    {
        tiempoActual = 0;
        foreach (MeshRenderer mesh in mallas)
        {
            mesh.material = interfazSinActivar;
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
                llamarAltavoces();

            }
            acumulador = 0;
        }


    }

    void llamarAltavoces()
    {
        controladorAltavoces.cambiarAleatorio();
        aleatorio = !aleatorio;
        if (aleatorio)
        {
            foreach (MeshRenderer mesh in mallas)
            {
                mesh.material = interfazActivada;
            }
        } else
        {
            foreach (MeshRenderer mesh in mallas)
            {
                mesh.material = interfazSinActivar;
            }
        }

    }

}

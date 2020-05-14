using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfazPausaMusica : InterfazBase
{
    public List<MeshRenderer> mallas;
    public Speakers controladorAltavoces;
    bool pausa = false;
    // Start is called before the first frame update
    override
    protected void Start()
    {
        tiempoActual = 0;
        foreach (MeshRenderer mesh in mallas)
        {
            mesh.material = interfazSinActivar;
        }
    }

    // Update is called once per frame
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
        if (controladorAltavoces.encendido)
        {
            controladorAltavoces.pausar();
            pausa = !pausa;

            if (pausa)
            {
                foreach (MeshRenderer mesh in mallas)
                {
                    mesh.material = interfazActivada;
                }
            }
            else
            {
                foreach (MeshRenderer mesh in mallas)
                {
                    mesh.material = interfazSinActivar;
                }
            }
        }
       

    }



}

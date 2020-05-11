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
    }

    override
   public void actuar()
    {
        if (tiempoActual <= 0)
        {
            tiempoActual = tiempoEsperar;
            llamarAltavoces();

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

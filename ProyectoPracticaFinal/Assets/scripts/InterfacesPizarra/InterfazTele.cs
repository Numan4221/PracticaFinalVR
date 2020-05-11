using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfazTele : InterfazBase
{
    public ControlPizarra controlPizarra;
    public List<MeshRenderer> mallas;
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

    override
    protected void Update()
    {


        if (tiempoActual > 0)
        {
            tiempoActual -= Time.deltaTime;
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

    override
   public void actuar()
    {
        if (tiempoActual <= 0)
        {
            tiempoActual = tiempoEsperar;
            StartCoroutine("llamarPizarra");

        }

    }


    IEnumerator llamarPizarra()
    {
        bool activado = false;

        while (!activado)
        {
            activado = true;
            yield return new WaitForSecondsRealtime(tiempoEsperar);
        }

        controlPizarra.gestionarEntrada(ControlPizarra.comandos.Tele);



    }



}

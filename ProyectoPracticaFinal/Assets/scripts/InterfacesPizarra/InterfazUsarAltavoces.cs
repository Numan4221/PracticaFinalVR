using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfazUsarAltavoces :InterfazBase
{
    public AudioSource altavoz;
    public bool altaDesactivado;
    override
     protected void Start()
    {
        encendido = false;
        tiempoActual = 0;
        altaDesactivado = false;
        if (altaDesactivado)
        {
            this.GetComponent<MeshRenderer>().material = interfazSinActivar;
        } else
        {
            this.GetComponent<MeshRenderer>().material = interfazActivada;
        }

    }

    override
        protected void Update()
    {
        if(tiempoActual > 0)
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
            cambiarEstado();

        }

    }

    void cambiarEstado()
    {

        Debug.Log(" el altavoz esta: " + altavoz.mute + " y alta activado es: " + altaDesactivado);
        altavoz.mute = !altaDesactivado;
        altaDesactivado= !altaDesactivado;
        if (altaDesactivado)
        {
            this.GetComponent<MeshRenderer>().material = interfazSinActivar;
        }
        else
        {
            this.GetComponent<MeshRenderer>().material = interfazActivada;
        }
        Debug.Log(" el altavoz esta: " + altavoz.mute + " y alta activado es: " + altaDesactivado);

        tiempoActual = tiempoEsperar;

    }
}

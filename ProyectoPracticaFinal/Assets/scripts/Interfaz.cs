using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interfaz : MonoBehaviour
{
    public ObjetoControlable miObjeto;
    public int tiempoEsperar;
    public float tiempoActual;
    public Material interfazSinActivar;
    public Material interfazActivada;
    bool encendido;
    // Start is called before the first frame update
    void Start()
    {
        encendido = false;
        tiempoActual = 0;
        this.GetComponent<MeshRenderer>().material = interfazSinActivar;
    }

    // Update is called once per frame
    void Update()
    {
        if (tiempoActual > 0)
        {
            tiempoActual -= Time.deltaTime;
            this.GetComponent<MeshRenderer>().material = interfazActivada;
        } else
        {
            this.GetComponent<MeshRenderer>().material = interfazSinActivar;
        }
    }


    public void actuar()
    {
        if(tiempoActual <= 0)
        {
            if (encendido)
            {
                miObjeto.apagar();
                encendido = false;
            } else
            {
                miObjeto.encender();
                encendido = true;
            }
            tiempoActual = tiempoEsperar;
            Debug.Log("actuando");
        }

    }


}

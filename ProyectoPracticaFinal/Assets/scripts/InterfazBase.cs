using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfazBase : MonoBehaviour
{
    protected float tiempoEsperar = 0.8f;
    public float tiempoActual;
    public Material interfazSinActivar;
    public Material interfazActivada;

    [SerializeField]
    protected float acumulador = 0;
    [SerializeField]
    protected bool pulsado = false;
    protected float tiempoAcumulador = 0.5f;
    // Start is called before the first frame update
    virtual
    protected void Start()
    {
        tiempoActual = 0;
        this.GetComponent<MeshRenderer>().material = interfazSinActivar;
    }

    // Update is called once per frame
    virtual
    protected void Update()
    {
        if (tiempoActual > 0)
        {
            tiempoActual -= Time.deltaTime;
            this.GetComponent<MeshRenderer>().material = interfazActivada;
        }
        else
        {
            this.GetComponent<MeshRenderer>().material = interfazSinActivar;
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

    virtual
    public void actuar()
    {
        Debug.Log("Metodo si Implementar");
    }

}

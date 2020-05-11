using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaCorredera : ObjetoControlable
{
    public float posCerrada;
    public float posAbierta;
    // Start is called before the first frame update
    void Start()
    {
        posCerrada = this.transform.localPosition.z;
        posAbierta = -1.71f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override
       public void apagar()
    {
        StartCoroutine("cerrarPuerta");
    }

    override
    public void encender()
    {
        StartCoroutine("abrirPuerta");

    }

    IEnumerator abrirPuerta()
    {
        while (this.transform.localPosition.z > posAbierta && !encendido)
        {
            this.transform.position = this.transform.position + new Vector3(0, 0, -Time.deltaTime);
            yield return null;
        }
        encendido = true;
    }

    IEnumerator cerrarPuerta()
    {
        while (this.transform.localPosition.z < posCerrada && encendido)
        {
            this.transform.position = this.transform.position + new Vector3(0, 0, +Time.deltaTime);
            yield return null;
        }
        encendido = false;
    }


}

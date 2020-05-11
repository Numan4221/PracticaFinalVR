using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoControlable : MonoBehaviour
{
    public bool encendido = false;

    virtual
    public void encender() {
        Debug.Log("implemente el metodo");
    }
    virtual
    public void apagar()
    {
        Debug.Log("implemente el metodo");
    }
}

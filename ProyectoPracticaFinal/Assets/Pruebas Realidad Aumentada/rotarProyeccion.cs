using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rotarProyeccion : MonoBehaviour
{
    public GameObject canvas;
    public Text consola;
    Vector3 rotacionAnterior;
    float rotAntY;
    // Start is called before the first frame update
    void Start()
    {

        rotacionAnterior = Quaternion.ToEulerAngles(this.transform.rotation);
        rotacionAnterior = rotacionAnterior * Mathf.Rad2Deg;
        print(this.name);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rotacionAnterior.ToString("F5") + " rot anterior");
        Vector3 rotacionActual = Quaternion.ToEulerAngles(this.transform.rotation) * Mathf.Rad2Deg;
        Debug.Log(rotacionActual.ToString("F5") + " rot actual");
        Vector3 cambioRotacion = rotacionActual - rotacionAnterior;
        Debug.Log(cambioRotacion.ToString("F5") + " cambio");
        canvas.transform.RotateAround(Vector3.zero, new Vector3(0, 0, 0), cambioRotacion.z);
        canvas.transform.RotateAround(Vector3.zero, new Vector3(1, 0, 0), cambioRotacion.x);
        canvas.transform.RotateAround(Vector3.zero,new Vector3(0,1,0),cambioRotacion.y);
        consola.text = cambioRotacion.ToString();
        rotacionAnterior = rotacionActual;
    }
}

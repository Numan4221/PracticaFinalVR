using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzarRayos : MonoBehaviour
{
    public LineRenderer rayoVisual;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
        for (int i = 0; i < rayoVisual.positionCount; i++)
        {
            if( i  == 0)
            {
                Vector3 cordPuntos = this.transform.position;
                rayoVisual.SetPosition(i, cordPuntos);
            } else
            {
                Vector3 cordPuntos = this.transform.position + new Vector3(0,0,1000);
                cordPuntos = this.transform.localRotation * cordPuntos;
                cordPuntos = cam.transform.rotation * cordPuntos;

                rayoVisual.SetPosition(i, cordPuntos);
            }
        }
        

        // solo queremos colisionar con la capa 9 de interfaz
        int layerMask = 1 << 9;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            hit.collider.gameObject.GetComponent<Interfaz>().actuar();
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
           // Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            //Debug.Log("Did not Hit");
        }




    }
}

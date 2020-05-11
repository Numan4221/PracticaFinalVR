using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MostrarCanal : MonoBehaviour
{
    public TextMeshPro text;
    public ReproductorVideo reproductor;
    // Start is called before the first frame update
    // Start is called before the first frame update
    void Start()
    {
        text.text = "Canal Elegido: " + reproductor.canal;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void actualizarCanal()
    {
        text.text = "Canal Elegido: " + reproductor.canal;
    }
}

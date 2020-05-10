using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MostrarVolumen : MonoBehaviour
{
    public TextMeshPro text;
    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "Volumen: " + audio.volume.ToString("F1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void actualizarVolumen()
    {
        text.text = "Volumen: " + audio.volume.ToString("F1");
    }
}

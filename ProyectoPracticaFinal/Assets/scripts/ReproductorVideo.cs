using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ReproductorVideo : ObjetoControlable
{
    public VideoPlayer reproductor;
    public AudioSource sonido;
    override
    public void apagar()
    {
        if (reproductor.isPlaying)
        {
            reproductor.Stop();
        }
        if (sonido.isPlaying)
        {
            sonido.Stop();
        }
    }

    override
    public void encender()
    {
        if (!reproductor.isPlaying)
        {
            reproductor.Play();
        }
        if (!sonido.isPlaying)
        {
            sonido.Play();
        }
    }

}

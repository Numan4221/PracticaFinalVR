using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speakers : ObjetoControlable
{
    public List<AudioSource> altavoces;
    public float volumen = 0.5f;
    public MostrarVolumen mostrador;

    void Start()
    {
        actualizarVolumen();
    }

    override
       public void apagar()
    {
        if (altavoces[0].isPlaying)
        {
            foreach (AudioSource altavoz in altavoces)
            {
                altavoz.Stop();
            }
        }
    }

    override
    public void encender()
    {
        if (!altavoces[0].isPlaying)
        {
            foreach (AudioSource altavoz in altavoces)
            {
                altavoz.Play();
            }
        }
    }


    public void subirVolumen()
    {
        if (volumen < 1)
        {
            volumen += 0.1f;
            actualizarVolumen();
        }
    }

    public void bajarVolumen()
    {
        if(volumen > 0.00001f)
        {
            volumen -= 0.1f;
            actualizarVolumen();
        }
    }


    public void actualizarVolumen()
    {
        foreach (AudioSource altavoz in altavoces)
        {
            altavoz.volume = volumen;
            mostrador.actualizarVolumen();
        }
    }

}

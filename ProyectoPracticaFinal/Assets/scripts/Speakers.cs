using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speakers : ObjetoControlable
{
    // de momento la cola es unica  pero habra que ampliarlo a 4 
    public List<AudioClip> listaReproducción;
    public int index = 0;
    public bool aleatorio = false;

    public List<AudioSource> altavoces;
    public float volumen = 0.5f;
    public MostrarVolumen mostrador;
    public bool pausado = false;

    void Start()
    {
        actualizarVolumen();
        foreach (AudioSource altavoz in altavoces)
        {
            altavoz.clip = listaReproducción[index];
        }
    }

    void Update()
    {
        if (encendido)
        {
            if (!pausado)
            {
                if (!altavoces[0].isPlaying)
                {
                    if (aleatorio)
                    {
                        int aux = Random.Range(0, listaReproducción.Count);
                        while (aux == index)
                        {
                            aux = Random.Range(0, listaReproducción.Count);
                        }
                        index = aux;
                        foreach (AudioSource altavoz in altavoces)
                        {
                            altavoz.clip = listaReproducción[index];
                            altavoz.Play();
                        }
                    }
                    else
                    {
                        if (++index == listaReproducción.Count)
                        {
                            index = 0;
                        }
                        foreach (AudioSource altavoz in altavoces)
                        {
                            altavoz.clip = listaReproducción[index];
                            altavoz.Play();
                        }
                    }

                }
            }
            
        }
    }

    override
       public void apagar()
    {
        if (altavoces[0].isPlaying)
        {
            encendido = false;
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
            encendido = true;
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

    public void cambiarAleatorio()
    {
        if (!aleatorio)
        {
            encendido = true;
            int aux = Random.Range(0, listaReproducción.Count);
            while (aux == index)
            {
                aux = Random.Range(0, listaReproducción.Count);
            }
            index = aux;
            foreach (AudioSource altavoz in altavoces){
                altavoz.Stop();
                altavoz.clip = listaReproducción[index];
                altavoz.Play();
            }
            aleatorio = true;
        } else
        {
            aleatorio = false;
        }
    }

    public void pausar()
    {
        if (encendido)
        {
            if (!pausado)
            {
                if (altavoces[0].isPlaying)
                {
                    pausado = true;
                    foreach (AudioSource altavoz in altavoces)
                    {
                        altavoz.Pause();
                    }
                }
            } else
            {
                pausado = false;
                foreach (AudioSource altavoz in altavoces)
                {
                    altavoz.Play();
                }
            }
           
        } 
        
    }

}

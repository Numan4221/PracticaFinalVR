using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ReproductorVideo : ObjetoControlable
{
    public List<VideoClip> canales;
    public List<AudioClip> sonidos;
    public VideoPlayer reproductor;
    public AudioSource sonido;
    public int canal = 2;
    bool modoCine = false;
    public GameObject interfazTele;
    Vector3 normalScale;
    Vector3 normalPos;
    Vector3 cinemaScale = new Vector3(15, 10, 10);
    Vector3 cinemaPos = new Vector3(0, 20, 50);
    public float volumen = 0.5f;
    public MostrarVolumen mostrador;

    void Start()
    {
        normalScale = this.transform.localScale;
        normalPos = this.transform.localPosition;
        reproductor.clip = canales[canal];
        sonido.clip = sonidos[canal];
        actualizarVolumen();
    }

    public void sigCanal()
    {
        if(++canal == canales.Count)
        {
            canal = 0;
        }
        reproductor.clip = canales[canal];
        sonido.clip = sonidos[canal];
        if (encendido)
        {
            reproductor.Play();
            sonido.Play();
        }

    }
    public void antCanal()
    {

        if (--canal < 0)
        {
            canal = canales.Count -1;
        }
        reproductor.clip = canales[canal];
        sonido.clip = sonidos[canal];
        if (encendido)
        {
            reproductor.Play();
            sonido.Play();
        }
    }


    override
    public void apagar()
    {
        encendido = false;
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
        encendido = true;
        if (!reproductor.isPlaying)
        {
            reproductor.Play();
        }
        if (!sonido.isPlaying)
        {
            sonido.Play();
        }
    }

    public void ponerCine()
    {
        if (!modoCine)
        {
            interfazTele.SetActive(false);
            this.transform.localScale = cinemaScale;
            this.transform.localPosition = cinemaPos;
            modoCine = true;
        } else
        {
            interfazTele.SetActive(true);
            this.transform.localScale = normalScale;
            this.transform.localPosition = normalPos;
            modoCine = false;
            
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
        if (volumen > 0.00001f)
        {
            volumen -= 0.1f;
            actualizarVolumen();
        }
    }

    public void actualizarVolumen()
    {
            sonido.volume = volumen;
            mostrador.actualizarVolumen();
        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPizarra : MonoBehaviour
{

    #region InterfacesNivel1
    public List<GameObject> interfazPrincipal;
    #endregion
    #region InterfazNivel2
    public List<GameObject> interfazMusica;
    public List<GameObject> interfazTele;
    public List<GameObject> interfazDecoracion;
    #endregion
    public enum pantallaActual { Principal,Musica,Tele,Decoracion}

    public enum comandos { Atras,Musica,Tele,Decoracion}

    public float tiempoEspera;
    private float tiempoActual = 0;

    pantallaActual nivel;


    // Start is called before the first frame update
    void Start()
    {
        nivel = pantallaActual.Principal;
        foreach (GameObject obj in interfazPrincipal)
        {
            obj.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(tiempoActual> 0)
        {
            tiempoActual -= Time.deltaTime;
        }
    }

    public void gestionarEntrada(comandos comando)
    {
        if(tiempoActual <= 0)
        {
            switch (comando)
            {
                case comandos.Musica:
                    abrirMusica();
                    break;
                case comandos.Atras:
                    switch (nivel)
                    {
                        case pantallaActual.Musica:
                            volverInterfazPrincipalDesdeMusica();
                            break;
                        case pantallaActual.Tele:
                            volverInterfazPrincipalDesdeTele();
                            break;
                        case pantallaActual.Decoracion:
                            volverInterfazPrincipalDesdeDecoracion();
                            break;
                    }
                    break;
                case comandos.Tele:
                    abrirTele();
                    break;
                case comandos.Decoracion:
                    abrirDecoracion();
                    break;
            }
            tiempoActual = tiempoEspera;
        }
       
    }

    public void abrirTele()
    {
        foreach (GameObject obj in interfazPrincipal)
        {
            obj.SetActive(false);
        }
        nivel = pantallaActual.Tele;
        foreach (GameObject obj in interfazTele)
        {
            obj.SetActive(true);
        }
    }

    public void abrirDecoracion()
    {
        foreach (GameObject obj in interfazPrincipal)
        {
            obj.SetActive(false);
        }
        nivel = pantallaActual.Decoracion;
        foreach (GameObject obj in interfazDecoracion)
        {
            obj.SetActive(true);
        }
    }

    public void abrirMusica()
    {
        foreach(GameObject obj in interfazPrincipal)
        {
            obj.SetActive(false);
        }
        nivel = pantallaActual.Musica;
        foreach(GameObject obj in interfazMusica)
        {
            obj.SetActive(true);
        }
    }
   
    public void volverInterfazPrincipalDesdeDecoracion()
    {
        foreach (GameObject obj in interfazDecoracion)
        {
            obj.SetActive(false);
        }
        nivel = pantallaActual.Principal;
        foreach (GameObject obj in interfazPrincipal)
        {
            obj.SetActive(true);
        }
    }

    public void volverInterfazPrincipalDesdeMusica()
    {
        foreach (GameObject obj in interfazMusica)
        {
            obj.SetActive(false);
        }
        nivel = pantallaActual.Principal;
        foreach (GameObject obj in interfazPrincipal)
        {
            obj.SetActive(true);
        }
    }

    public void volverInterfazPrincipalDesdeTele()
    {
        foreach (GameObject obj in interfazTele)
        {
            obj.SetActive(false);
        }
        nivel = pantallaActual.Principal;
        foreach (GameObject obj in interfazPrincipal)
        {
            obj.SetActive(true);
        }
    }



}

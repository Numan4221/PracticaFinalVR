﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubirVolumenMusica : InterfazBase
{
    
    public Speakers controladorAltavocez;
    // Start is called before the first frame update
    override
    protected void Start()
    {
        tiempoEsperar = 0.2f;
    }

    override
    public void actuar()
    {
        if (tiempoActual <= 0)
        {
            tiempoActual = base.tiempoEsperar;
            controladorAltavocez.subirVolumen();

        }
    }


}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfazBajarVolumenTele : InterfazBase
{
    public ReproductorVideo reproductor;
    // Start is called before the first frame update
    override
    protected void Start()
    {
        tiempoEsperar = 0.2f;
    }
    // Update is called once per frame
    override
    public void actuar()
    {
        if (tiempoActual <= 0)
        {
            tiempoActual = base.tiempoEsperar;
            reproductor.bajarVolumen();

        }
    }
}
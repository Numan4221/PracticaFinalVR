using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfazSIguienteCuadro : InterfazBase
{

    public GetsorDecorador gestor;
    public int num;

    override
public void actuar()
    {

        acumulador += Time.deltaTime;
        pulsado = true;

        if (acumulador > tiempoAcumulador)
        {
            if (tiempoActual <= 0)
            {
                tiempoActual = base.tiempoEsperar;
                switch (num)
                {
                    case 0:
                        gestor.cambiarCuadroAlargado();
                        break;
                    case 1:
                        gestor.cambiarCuadroRectangular();
                        break;
                    case 2:
                        gestor.cambiarCuadroCuadrado();
                        break;

                }


            }
            acumulador = 0;
        }


      
    }
}

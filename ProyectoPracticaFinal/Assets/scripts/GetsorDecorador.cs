using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetsorDecorador : MonoBehaviour
{
    public List<Material> cuadrosAlargados;
    public List<Material> cuadrosRectangulares;
    public List<Material> cuadrosCuadrados;
    int indexAlargado = 0;
    int indexRectangular = 0;
    int indexCuadrado = 0;
    int indiceGeneral = 0;
    public MeshRenderer cuadroAlargado;
    public MeshRenderer cuadroRectangular;
    public MeshRenderer cuadroCuadrado;

    // Start is called before the first frame update
    void Start()
    {
        asignarModeloDecorativo(indiceGeneral);
    }


    public void asignarModeloDecorativo(int num)
    {
        cuadroAlargado.material = cuadrosAlargados[num];
        cuadroRectangular.material = cuadrosRectangulares[num];
        cuadroCuadrado.material = cuadrosCuadrados[num];
        indexAlargado = num;
        indexCuadrado = num;
        indexRectangular = num;
        indiceGeneral = num;
    }


    public void cambiarCuadroCuadrado()
    {
        if(++indexCuadrado == cuadrosCuadrados.Count)
        {
            indexCuadrado = 0;
        }
        cuadroCuadrado.material = cuadrosCuadrados[indexCuadrado];
    }

    public void cambiarCuadroRectangular()
    {
        if (++indexRectangular == cuadrosRectangulares.Count)
        {
            indexRectangular = 0;
        }
        cuadroRectangular.material = cuadrosRectangulares[indexRectangular];
    }

    public void cambiarCuadroAlargado()
    {
        if (++indexAlargado == cuadrosAlargados.Count)
        {
            indexAlargado = 0;
        }
        cuadroAlargado.material = cuadrosAlargados[indexAlargado];
    }







}

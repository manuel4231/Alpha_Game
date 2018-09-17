using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeleccionJugador : MonoBehaviour
{

    public int Nivel1;
    public int Nivel2;
    public int Nivel3;


    public void CambioNivel1()
    {
        SceneManager.LoadScene(Nivel1);
    }

    public void CambioNivel2()
    {
        SceneManager.LoadScene(Nivel2);
    }

    public void CambioNivel3()
    {
        SceneManager.LoadScene(Nivel3);
    }

}
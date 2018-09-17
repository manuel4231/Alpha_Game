using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscena : MonoBehaviour {

    public int Jugadores;
    public int Creditos;
    public int Menu;
    public int Nivel1;
    public int Nivel2;
    public int Nivel3;


    public void CambioJugador()
    {
        SceneManager.LoadScene(Jugadores);
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit");
    }

    public void CambioCreditos()
    {
        SceneManager.LoadScene(Creditos);
    }

    public void CambioMenu()
    {
        SceneManager.LoadScene(Menu);
    }

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coleccion : MonoBehaviour
{
    public int acumulado = 0;
    public int Win;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnCollisionEnter(Collision _colision)
    {
        if (_colision.gameObject.tag == "Jugador")
        {
            Recolectable recolectado = _colision.gameObject.GetComponent<Recolectable>();
            //recolectado.Cogido();
            acumulado++;
        }

        if(acumulado >= 3f)
        {
            SceneManager.LoadScene(Win);
            acumulado = 0;
        }
    }

    
}
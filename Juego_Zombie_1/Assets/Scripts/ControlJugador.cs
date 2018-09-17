using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Renderer))]

public class ControlJugador : MonoBehaviour, IDestruccion {

    Movimiento mMovimiento;
    Slider laUtilidad;
    Coleccion laColeccion;
    public int GameOver;
    public float t = 0;
    public float cantidadRecolectables = 0;
    public float cantidadDistractores = 0;
    public float vida = 3f;
    public float Salud = 100;
    Capturador mCapturador;
    GameObject Sangre;
    Renderer renderPlano;
    GameObject Palpitacion;
    Transform elCarro;
    Transform mTransform;
    public float Choques = 0;

    // Use this for initialization
    void Start()
    {
        mMovimiento = GetComponent<Movimiento>();
        laUtilidad = GetComponentInChildren<Slider>();
        laColeccion = GetComponent<Coleccion>();
        Sangre = GameObject.FindGameObjectWithTag("Sangre");
        Palpitacion = GameObject.FindGameObjectWithTag("Palpitacion");
        renderPlano = GetComponentInChildren<Renderer>();
        mTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        t += Time.deltaTime;
      
        mMovimiento.Mover();
       
        if (Salud <= 0)
        {
            Muere();
        }
        if (t >= 300)
        {
            SceneManager.LoadScene(GameOver);
        }
        // Para el ruido sería hacer un collider trigger que vaya aumentando conforme el input --> Vector3 (1,1,1) x 10 x input

    }

    public void Destruir(float Cantidad)
    {
        Salud -= Cantidad;
    }

    public void Muere()
    {
        if(Salud <= 0)
        {
            vida--;
            Salud = 100;
        }        
        if(vida == 0)
        {
            SceneManager.LoadScene(GameOver);
        }
    }
}
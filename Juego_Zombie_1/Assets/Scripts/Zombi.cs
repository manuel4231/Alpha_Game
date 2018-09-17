using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombi : MonoBehaviour {

    bool patrullando = true, enRango = false; // Se incializan bools de comportamiento
    float velocidad = 2; // vel de persecusión
    NavMeshAgent navAgent; // Comportamiento de la AI
    Transform mTransform, posA, posB, jugador; // Posiciones de referencia para conductas
    Movimiento movJugador;   
    Vector3 posInicial2;

	public void Start () {
        navAgent = GetComponent<NavMeshAgent>();       
        jugador = GameObject.Find("Jugador").GetComponent<Transform>();
        movJugador = GameObject.Find("Jugador").GetComponent<Movimiento>();
        mTransform = GetComponent<Transform>();
        posInicial2 = new Vector3(mTransform.position.x, mTransform.position.y, mTransform.position.z);
       
    }
	
	void Update () {
        if (patrullando == true)
        { Patrullar(); } // Solo se ejecuta la función en el tiempo si la condición se cumple

        Atacar(); // Siempre se evalúa en el tiempo
        if (movJugador.meDetectan == true)
        {
            DetectadoJugador();
        }
	}
    public void Atacar()
    {
        Vector3 rangoJugador = mTransform.position - jugador.position; // Rango para determinar area hacia el jugador
        if (rangoJugador.sqrMagnitude <= 100) // Si el jugador está mas cerca de 100uds entonces
        {
            navAgent.ResetPath(); // Reinicia el path para que no siga queriendo patrullar y no se reduzca la velocidad a causa de él
            enRango = true; // Activa condición de enRango
            patrullando = false; // Desactiva patrullando para que no se ejecute en el tiempo
            if (enRango == true)
            {
                mTransform.LookAt(jugador.position); // Mirar siempre al jugador
                mTransform.position += mTransform.forward * Time.deltaTime * velocidad; // Moverese a una velocidad determinada por vel en variables en el tiempo
            }
        }
        if (rangoJugador.sqrMagnitude >= 100) // Si está el jugador lejos del zombi, a 100uds
        {
            enRango = false; // Desactivo la persecusión
            patrullando = true; // Empiezo a patrullar activando la función
        }


    }
    public void Patrullar()
    {
        Vector3 rangoZombi = mTransform.position - posInicial2; // Rango para determinar area hacia el jugador
       
        if(mTransform.position!= posInicial2)
        {
            
            if(rangoZombi.sqrMagnitude >= 5)
            {
                print("Estoy tratando de ir pero soy retrasado.");
                mTransform.LookAt(posInicial2); // Mirar siempre al jugador
                mTransform.position += mTransform.forward * Time.deltaTime * velocidad; // Moverese a una velocidad determinada por vel en variables en el tiempo
            }

        }


       

    }
    void OnCollisionEnter(Collision _colisionado)
    {
        GameObject colisiona = _colisionado.gameObject;
        //Debug.Log("Entró a la colisión propia del zombi");
        if (_colisionado.transform.GetComponent<IDestruccion>() != null)
        {
            Debug.Log("Pegué");
            _colisionado.transform.GetComponent<IDestruccion>().Destruir(20);
        }

    }

    public void DetectadoJugador()
    {
        Vector3 rangoJugador = mTransform.position - jugador.position;
        if (rangoJugador.sqrMagnitude <= 500)
        {
            patrullando = false;
            mTransform.LookAt(jugador.position); // Mirar siempre al jugador
            mTransform.position += mTransform.forward * Time.deltaTime * velocidad; // Moverese a una velocidad determinada por vel en variables en el tiempo
        }
    }
   
}

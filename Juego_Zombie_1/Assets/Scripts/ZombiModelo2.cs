using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombiModelo2 : MonoBehaviour {

    public bool patrullando = true, voyA = false, voyB = false, enRango = false; // Se incializan bools de comportamiento

    [SerializeField]
    float velocidad = 2; // vel de persecusión
    public NavMeshAgent navAgent; // Comportamiento de la AI
    Transform mTransform, posA, posB, posInicial, jugador; // Posiciones de referencia para conductas

	void Start () {
        navAgent = GetComponent<NavMeshAgent>();
        posA = GameObject.Find("Punto C").GetComponent<Transform>();
        posB = GameObject.Find("Punto D").GetComponent<Transform>();
        jugador = GameObject.Find("Jugador").GetComponent<Transform>();
        mTransform = GetComponent<Transform>();
        posInicial = mTransform;
        voyA = true; // Inicializo voyA para que empiece patrullando hacia el punto de A, una única vez
    }
	
	void Update () {
        if (patrullando == true) { Patrullar(); } // Solo se ejecuta la función en el tiempo si la condición se cumple
        Atacar(); // Siempre se evalúa en el tiempo
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
        // Rangos de llegada a puntos de patrulla
        Vector3 rangoPosA = mTransform.position - posA.position;
        Vector3 rangoPosB = mTransform.position - posB.position;
        if (voyA == true) // Empieza en el start con esta condición
        {
            if (rangoPosA.sqrMagnitude >= 5)
            {
                navAgent.SetDestination(posA.position); // Empieza a ir hacia A si estoy más lejos de 5uds
            }
            if (rangoPosA.sqrMagnitude < 5)
            {
                navAgent.ResetPath(); // Reinicio el path porque ya llegó a 5uds cerca
                voyA = false; // Desactivo voyA porque no quiere ir otra vez hacia A
                voyB = true; // Activo voyB porque quiere ir hacia B
            }
        }
        if (voyB == true)
        {
            if (rangoPosB.sqrMagnitude >= 5)
            {
                navAgent.SetDestination(posB.position); // Empieza a ir hacia B si estoy más lejos de 5uds
            }
            if (rangoPosB.sqrMagnitude < 5)
            {
                navAgent.ResetPath();
                voyA = true; // Activo voyA porque quiere ir hacia A
                voyB = false; // Desactivo voyB porque no quiere ir otra vez hacia B
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

    public void Muere()
    {
        Destroy(gameObject);
    }
}

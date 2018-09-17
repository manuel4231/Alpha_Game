using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickUp : MonoBehaviour {

    
    ControlJugador mJugador;
    AudioSource mAudio;
    GameObject pickUp;
    Movimiento mMovimiento;

    

    // Use this for initialization
    void Start()
    {
        mAudio = GetComponent<AudioSource>();
        pickUp = GetComponent<GameObject>();
        mJugador = GetComponent<ControlJugador>();
        mMovimiento = GetComponent<Movimiento>();
    }
    private void OnCollisionEnter(Collision _colision)
    {
        if (_colision.gameObject.tag == "Vida")
        {
            mJugador.vida += 1f;
        }
        if (_colision.gameObject.tag == "Recolectable")
        {
            mJugador.cantidadRecolectables++;
        }
        if (_colision.gameObject.tag == "Distractor")
        {
            mJugador.cantidadDistractores++;
        }
    }
}

       
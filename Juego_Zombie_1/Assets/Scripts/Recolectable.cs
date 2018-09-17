using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recolectable : MonoBehaviour {

    AudioSource mAudio;

    void Start()
    {
        mAudio = GetComponent<AudioSource>();


    }
    void OnCollisionEnter(Collision _colision)
    {
        if (_colision.gameObject.tag == "Jugador")
        {
            mAudio.Play();
            Destroy(gameObject);          
        }
    }
}


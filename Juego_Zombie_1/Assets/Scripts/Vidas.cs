using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vidas : MonoBehaviour {

    AudioSource mAudio;
     
    void Start()
    {
        mAudio = GetComponent<AudioSource>();             
        
    }
    void Update()
    {

    }
    
    void OnCollisionEnter(Collision _colision)
    {
        if(_colision.gameObject.tag == "Jugador")
        {
            mAudio.Play();
            Destroy(gameObject);
        }
    }
 
   



}

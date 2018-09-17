using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coleccionables : MonoBehaviour {

    AudioSource mAudio;
    GameObject pickUp;
   
   

    // Use this for initialization
    void Start()
    {
        mAudio = GetComponent<AudioSource>();
        pickUp = GetComponent<GameObject>();
       
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Cogido()
    {                
              
        mAudio.Play();        
        Destroy(gameObject);

    }
  
}

       
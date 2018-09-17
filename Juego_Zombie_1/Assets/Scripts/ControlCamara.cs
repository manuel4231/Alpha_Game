using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamara : MonoBehaviour {

    Camara mCamara;

	// Use this for initialization
	void Start () {

        mCamara = GetComponent<Camara>();
		
	}
	
	// Update is called once per frame
	void Update () {

        mCamara.Mover();
        
	}
}

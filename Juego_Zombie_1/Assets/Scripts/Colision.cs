using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Colision : MonoBehaviour {

	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnCollisionEnter(Collision _colisionado)
    {

        if (_colisionado.transform.GetComponent<IColision>() != null)
        {
            Debug.Log("Holiwix");
            _colisionado.transform.GetComponent<IColision>().Colisiona();
        }
    }
}

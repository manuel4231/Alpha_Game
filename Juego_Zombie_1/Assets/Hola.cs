using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hola : MonoBehaviour {

    public TextMeshProUGUI segundero;
    float cuenta;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        cuenta = cuenta + Time.deltaTime;
        segundero.text = cuenta.ToString("F2");

	}
}

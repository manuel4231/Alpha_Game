using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasChechks : MonoBehaviour {

    public Text actuales;
    public Canvas canvas;
    public Toggle checkbox;

    ControlJugador Jugador;

    int contador = 0;
    // Use this for initialization
    void Start () {
        Jugador = GetComponent<ControlJugador>();
	}
	
	// Update is called once per frame
	void Update () {

        Jugador.cantidadRecolectables = contador;

        if (Jugador.cantidadRecolectables == contador)
        {
            contador++;
            actuales.text = contador.ToString();
        }
                
        if (contador >= 6)
        {
           checkbox.isOn = true;
        }
    }
}

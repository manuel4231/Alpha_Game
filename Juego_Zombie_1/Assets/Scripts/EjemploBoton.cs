using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EjemploBoton : MonoBehaviour {

    public GameObject boton;

    public Text textoTiempo;

    public void DecirHola()
    {
        Debug.Log("Hola a todos");
        boton.SetActive(false);
        
    }

}

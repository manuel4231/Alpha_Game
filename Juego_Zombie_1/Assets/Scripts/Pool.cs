using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour {

    public static Pool Piscina; //Este nombre es para llamarlo en otros scripts.
    public void Awake() //Ejecutarse antes del Start, siempre se está llamando. 
    {
        Piscina = this; //Siempre este script es igual a this script (piscina = pool)
    }

    private float numeroDeObjetos = 4;
    List<GameObject> piscina;
    GameObject distractor;

	// Use this for initialization
	void Start () {

        distractor = GameObject.Find("Distractor arrojable");
        piscina = new List<GameObject>(); //Se inició una nueva lista para poder crearla

        for (int i = 0; i < numeroDeObjetos; i++)
        {
            GameObject distractorClon = Instantiate(distractor); //Se crea el clon.
            distractorClon.SetActive(false); //Desactiva el clon
            piscina.Add(distractorClon); //Se agrega a la lista
        }

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject SacarDeLaPool() //La garra, va a devolver un GameObject
    {
        for (int i = 0; i < piscina.Count; i++) //Count es un atributo de List (cantidad de elementos de la lista)
        {
            if(piscina[i].activeInHierarchy == false)//Preguntarle al objeto de la piscina en ese punto si está desactivado  
            {
                return piscina[i]; //Devolver objeto de la piscina en esa posición del arreglo
            }


        }
        return null; //Si no lo puedo devolver, entonces nulo
    }
}

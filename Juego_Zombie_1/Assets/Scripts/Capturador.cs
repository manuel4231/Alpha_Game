using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Capturador : MonoBehaviour {

    bool pausa = false;
    public Text actuales;
    public Canvas canvas;
    //public Toggle checkbox;

    public bool carritocoje;

   float contador = 0; //conteo de objetos capturados
                      // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        if (Input.GetButtonDown("Fire2")) {
            pausa = !pausa;
        }

        if (pausa)
        {
            Time.timeScale = 0f;
        }
        else {
            //Invoke("Reanudar", 2f);
            Time.timeScale = 1f;
        }

        canvas.enabled = pausa;

        }
    }



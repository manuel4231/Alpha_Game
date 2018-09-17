using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timerText;
    private float startTime;
    private bool finnished = false;
    public float t;
    GameObject Jugador;
    ControlJugador mJugador;

    // Use this for initialization
    void Start()
    {
        Debug.Log(name);
        startTime = Time.time;
        Jugador = GameObject.Find("Jugador");
        mJugador = GetComponent<ControlJugador>();
    }

    // Update is called once per frame
    void Update()
    {
        if (finnished)
            return;

        t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");  // MODULO (%) PARA CONVERTIR DE SEGUNDOS AMINUTOS .... 

        timerText.text = minutes + ":" + seconds;
    }

    public void Muriendo() // cuando el tiempo se está agotando en muriendo la función
    {
        finnished = true;
        timerText.color = Color.red;
        
        
    }

   public void TiempoAcabado()
    {
        if(t >= 1f)
        {
            
            Muriendo();
        }
    }
    

}

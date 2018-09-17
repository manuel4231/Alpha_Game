using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnCaptura : MonoBehaviour {

    public delegate void EventoCaptura();
    public static event EventoCaptura VelocidadDoble;
    Movimiento mMovimiento;
    GameObject Recolectable;
    float Tiempo = 0;
    float Tiempo2 = 0;

    // Use this for initialization
    void Start()
    {
        Recolectable = GameObject.Find("pumpkin");
        mMovimiento = GetComponent<Movimiento>();
    }

    // Update is called once per frame
    void Update()
    {
        Tiempo += Time.deltaTime;
        Tiempo2 += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision Aumento)
    {

        if (Aumento.gameObject.tag == "Recolectable" && VelocidadDoble != null && Tiempo2 >= 5)
        {
            Tiempo = 0;
            VelocidadDoble();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movimiento : MonoBehaviour
{
  
    Slider mSlider;
    public float Magnitud = 5;
    public float MagnitudAngular;
    Transform mTransform;
    AudioSource mAudio;
    public bool meDetectan = false;
    public bool hijo = false;
    public float tiempo = 0;


   
 

    // Use this for initialization
    void Start()
    {
        mSlider = GetComponentInChildren<Slider>();
        mTransform = GetComponent<Transform>();
        mAudio = GetComponent<AudioSource>();
       
        EnCaptura.VelocidadDoble += DobleVelocidad;

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Mover()
    {

        Vector3 direccionX = new Vector3(1, 0, 0);
        Vector3 direccionZ = mTransform.forward;
        Vector3 direccionY = new Vector3(0, 1, 0);

        float sentidoZ = Input.GetAxisRaw("Vertical");
        float sentidoY = Input.GetAxisRaw("Horizontal");
        //Debug.Log(sentidoZ);
        
        Vector3 velocidadAngular = MagnitudAngular * direccionY * sentidoY;
        Vector3 desplazamientoAngular = velocidadAngular * Time.deltaTime;
        mTransform.eulerAngles += desplazamientoAngular;

        Vector3 velocidad = Magnitud * (direccionZ * sentidoZ);
        Vector3 desplazamiento = velocidad * Time.deltaTime;
        mTransform.position += desplazamiento;

       

        if (sentidoY != 0)
        {
            mAudio.mute = false;
        }
        else
        {
            mAudio.mute = true;
        }
        if (sentidoZ != 0)
        {
            mAudio.mute = false;
        }   
    }
    public void Detectado()
    {
        meDetectan = true;
    }

    public void DobleVelocidad()
    {
        Debug.Log("Aumento en 10");
        Magnitud = 10;
    }

}

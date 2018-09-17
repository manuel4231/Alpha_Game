using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour {

    public float Magnitud;
    public float MagnitudAngular;
    Transform mTransform;
    AudioSource mAudio;

    // Use this for initialization
    void Start()
    {

        mTransform = GetComponent<Transform>();
        mAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Mover()
    {

        Vector3 direccionX = new Vector3(1, 0, 0);

        float sentidoX = Input.GetAxis("VerticalCamara");
        //Debug.Log(sentidoX);

        Vector3 velocidadAngular = MagnitudAngular * direccionX * sentidoX * -1;
        Vector3 desplazamientoAngular = velocidadAngular * Time.deltaTime;
        mTransform.eulerAngles += desplazamientoAngular;

        if (sentidoX != 0)
        {
            mAudio.mute = false;
        }

    }
}

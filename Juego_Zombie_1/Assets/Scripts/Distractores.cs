using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distractores : PickUp {

    void OnCollisionEnter(Collision _colision)
    {
        if (_colision.gameObject.tag == "Jugador")
        {
            Destroy(gameObject);
        }
    }
}

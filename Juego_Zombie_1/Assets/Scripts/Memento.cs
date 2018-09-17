using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memento { 

    public Vector3 pos;
    public Vector3 rot;
  
    public Memento(Vector3 _pos, Vector3 _rot)
    {
        pos = _pos;
        rot = _rot;
        
    }
}


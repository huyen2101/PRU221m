using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TowerEnum 
{
    public string id;
    public Vector3 position; 
    public TowerEnum(Vector3 position, string id)
    {
        this.position = position;
        this.id = id;
    }
}

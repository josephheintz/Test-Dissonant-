using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GearType{
    Equipment,
    Weapon,
    Resource,
    Nothing
}

public abstract class Gear : ScriptableObject
{

    public GameObject prefab;
    public GearType type;
    [TextArea(15,20)]
    public string notes;
}

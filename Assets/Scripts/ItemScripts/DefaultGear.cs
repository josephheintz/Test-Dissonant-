using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Gear", menuName = "Inventory System/Gear/DefaultGear")]

public class DefaultGear : Gear
{
    public void Awake(){
        type = GearType.Nothing;
    }
}

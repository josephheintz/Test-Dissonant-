using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment Gear", menuName = "Inventory System/Gear/EquipmentGear")]

public class Equipment : Gear
{
    public void Awake(){
        type = GearType.Equipment;
    }
}

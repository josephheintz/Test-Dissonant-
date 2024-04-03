using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Gear", menuName = "Inventory System/Gear/WeaponGear")]

public class Weapons : Gear
{
        public bool holding;
        public int damage;
        public int electric;
        public int water;
        public int fire;
        public int wind;

    public void Awake(){
        type = GearType.Weapon;
    }
}

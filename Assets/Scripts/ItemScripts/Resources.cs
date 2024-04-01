using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Gear", menuName = "Inventory System/Gear/Resources")]

public class Resources : Gear
{

    //public int crystals;
    //public int wood;
    //public int metal;
    //public int bone;
    //public int obsidian;

        public void Awake(){
            type = GearType.Resource;
        }

}

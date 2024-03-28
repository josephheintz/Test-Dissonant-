using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{

    // Define the custom data type for equipment Weapon
    [System.Serializable] public class Weapon
    {
        public string name;
        public bool holding;
        public int damage;
        public int electric;
        public int water;
        public int fire;
        public int wind;
    }

    // Define the custom data type for equipment items
    [System.Serializable] public class Item
    {
        public string name;
        public bool have;
    }

}

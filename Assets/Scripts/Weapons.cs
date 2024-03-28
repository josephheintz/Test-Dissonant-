using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    // Define the custom data type for equipment items
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

    // Define the equipment slots and initialize them with instances of the Item class
    [SerializeField] public Weapon slotOne;
    [SerializeField] public Weapon slotTwo;
    [SerializeField] public Weapon slotThree;

    // Example initialization in Start() method
    void Start()
    {
        // Initialize the equipment slots with new instances of the Item class
        slotOne = new Weapon();
        slotTwo = new Weapon();
        slotThree = new Weapon();
    }
}

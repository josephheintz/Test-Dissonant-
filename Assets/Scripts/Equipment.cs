using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    // Define the custom data type for equipment items
    [System.Serializable] public class Item
    {
        public string name;
        public bool have;
    }

    // Define the equipment slots and initialize them with instances of the Item class
    [SerializeField] public Item slotOne;
    [SerializeField] public Item slotTwo;
    [SerializeField] public Item slotThree;

    // Example initialization in Start() method
    void Start()
    {
        // Initialize the equipment slots with new instances of the Item class
        slotOne = new Item();
        slotTwo = new Item();
        slotThree = new Item();
    }
}

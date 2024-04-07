using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    // Reference to the InventoryObject scriptable object
    public InventoryObject inventory;

    // Prefab of the player object
    private GameObject player;

    // Boolean flag to determine whether to clear the inventory on quit
    [SerializeField] public bool clear = true;

    // Start is called before the first frame update
    public void Start()
    {
        // Find the player object in the scene by tag
        GameObject playerPrefab = GameObject.FindGameObjectWithTag("Player");
    }

    // OnTriggerEnter2D is called when the Collider2D other enters the trigger
    public void OnTriggerEnter2D(Collider2D other)
    {
        // Get the Item component from the collided object
        var item = other.GetComponent<Item>();

        // Check if the collided object has an Item component
        if (item != null)
        {
            // Add the gear from the item to the inventory
            inventory.AddGear(item.gear, 1);

            // Destroy the collided object
            Destroy(other.gameObject);
        }
    }

    // OnApplicationQuit is called when the application is about to quit
    private void OnApplicationQuit()
    {
        // Check if the inventory object and its container are not null
        if (inventory != null && inventory.Container != null)
        {
            // If clear flag is false, set amount of all items in the container to 0
            if (!clear)
            {
                for (int i = 0; i < inventory.Container.Count; i++)
                {
                    inventory.Container[i].amount = 0;
                }
            }

            // If clear flag is true, clear the container
            if (clear)
            {
                inventory.Container.Clear();
            }
        }
    }
}

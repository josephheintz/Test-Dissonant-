using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public InventoryObject inventory;
    private GameObject player; // Prefab of the player object
    //public Collider2D triggerCollider; // Collider to use for triggering
    [SerializeField] public bool clear = true;


    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //Debug.Log(player);

        //triggerCollider = player.GetComponent<Collider2D>();
    }

    public void OnTriggerEnter2D(Collider2D other){
        var item = other.GetComponent<Item>();

        if(item != null){
            inventory.AddGear(item.gear, 1);
            Destroy(other.gameObject);
        }
    }

    private void OnApplicationQuit(){
        if(inventory != null && inventory.Container != null) {

            if(!clear) for(int i = 0; i < inventory.Container.Count; i++) inventory.Container[i].amount = 0;
            if(clear) inventory.Container.Clear();

        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public InventoryObject inventory;

    public void OnTriggerEnter2D(Collider2D other){
        var item = other.GetComponent<Item>();

        if(item != null){
            inventory.AddGear(item.gear, 1);
            Destroy(other.gameObject);
        }
    }

    private void OnApplicationQuit(){
        if(inventory != null && inventory.Container != null) {

            for(int i = 0; i < inventory.Container.Count; i++) inventory.Container[i].amount = 0;

            //inventory.Container.Clear();

        }
    }

}

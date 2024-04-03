using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "InventorySystem/Inventory")]

public class InventoryObject : ScriptableObject
{
    public List<ItemSlot> Container =  new List<ItemSlot>();
    public void AddGear(Gear _gear, int _amount){
        bool has = false;

        for(int i = 0; i < Container.Count; i++){
            if(Container[i].item == _gear){
                has = true;
                Container[i].addAmount(_amount);
                break;
            }
        }

        if(has == false){
            Container.Add(new ItemSlot(_gear, _amount));
        }

    }

    // Define the custom data type for equipment Weapon
    [System.Serializable] public class ItemSlot
    {
        public Gear item;
        public int amount;
        public ItemSlot(Gear _item, int _amount){
            item = _item;
            amount = _amount;
        }

        public void addAmount(int value){
            amount = amount + value;
        }

    }
}

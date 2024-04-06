using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    [Header("UI")] public GameObject inventory;
    public List<Slot> InventorySlots = new List<Slot>();

    [Header("Crafting")] public List<Recipe> itemRecipes = new List<Recipe>();
    
    public void Start()
    {
        foreach (Slot uiSlot in InventorySlots)
        {
            uiSlot.initializeSlot();
        }
    }

    public void Update()
    {
        itemRaycast(Input.GetMouseButtonDown(0));
    }

    private void addItemToInventory(Item item)
    {
        
    }

    public void craftItem(string itemName)
    {
        foreach (Recipe recipe in itemRecipes)
        {
            if (recipe.createdItemPrefab.GetComponent<Item>().name == itemName)
            {
                bool haveAllIngredients = true;
                for (int i = 0; i < recipe.requiredIngredients.Count; i++)
                {
                    if (haveAllIngredients)
                        haveAllIngredients = haveIngredient(recipe.requiredIngredients[i].itemName,
                            recipe.requiredIngredients[i].requiredQuantity);
                }
            }
        }
    }

    private bool haveIngredient(string itemName, int quantity)
    {
        int foundQuantity = 0;
        
        foreach (Slot curSlot in allInventorySlots)
        {
            if (curSlot.hasItem() && curSlot.getItem().name == itemName)
            {
                foundQuantity += curSlot.getItem().currentQuantity;
                
                if (foundQuantity >= quantity)
                    return true;
            }
        }
        
        return false;
    }
    
}

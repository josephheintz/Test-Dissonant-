using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Boolean value to check if pointer is hovering over slot
    public bool hovered;
    // item in the slot
    private Item heldItem;
    
    private Color opaque = new Color(1, 1, 1, 1);
    private Color transparent = new Color(1, 1, 1, 0);
    // Image for the slot
    private Image thisSlotImage;

    
    public void initializeSlot()
    {
        thisSlotImage = gameObject.GetComponent<Image>();
        thisSlotImage.sprite = null;
        thisSlotImage.color = transparent;
        setItem(null);
    }

    public void getItem(Item item)
    {
        
    }

    public Item getItem()
    {
        return heldItem;
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        hovered = true;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        hovered = false;
    }
}

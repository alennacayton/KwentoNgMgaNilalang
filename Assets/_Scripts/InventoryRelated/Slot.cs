using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    Item currentItem;
    Image currentItemDisplay;

    [SerializeField] int slotIndex;

    public void Awake()
    {
        currentItemDisplay = GetComponentInChildren<Image>();
        RemoveItem();
        //Debug.Log("Item #" + slotIndex + " has been created and item removed");
    }

    public void AddItem(Item item)
    {
        currentItem = item;
       
        currentItemDisplay.sprite = item.itemSprite;
        currentItemDisplay.enabled = true;
    }

    public void RemoveItem()
    {
        currentItemDisplay.enabled = false;
        currentItemDisplay.sprite = null;
        currentItem = null;
    }
}

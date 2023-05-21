using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private int capacity = 12;
    [SerializeField] private List<Item> inventoryItems = new List<Item>();

    public void AddItemToInventory(Item newItem)
    {
        inventoryItems.Add(newItem);
    }

    public void RemoveItemFromInventory(int index)
    {
        inventoryItems.RemoveAt(index);
    }

    public Item GetInventoryItemAtIndex(int index)
    {
        if(index >= inventoryItems.Count)
            return null;
        return inventoryItems[index];
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ObjectInventory : MonoBehaviour
{
    public List<Item> inventoryItems = new List<Item>();

    public void AddItemsToInventory(List<Item> newItems)
    {
        inventoryItems.AddRange(newItems);
    }

    public void TransferItemsToPlayer()
    {
        PlayerInventory playerInventory = FindObjectOfType<PlayerInventory>();

        if(inventoryItems.Count > 0)
        {
            foreach (Item item in inventoryItems)
                playerInventory.AddItemToInventory(item);

            inventoryItems.Clear();
        }
    }

}
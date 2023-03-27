using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        playerInventory.AddItemsToInventory(inventoryItems);

        inventoryItems.Clear();
    }

}

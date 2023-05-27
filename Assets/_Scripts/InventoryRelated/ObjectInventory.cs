using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ObjectInventory : MonoBehaviour
{
    public List<Note> inventoryItems = new List<Note>();

    public void AddItemsToInventory(List<Note> newItems)
    {
        inventoryItems.AddRange(newItems);
    }

    public void TransferItemsToPlayer()
    {
        PlayerInventory playerInventory = FindObjectOfType<PlayerInventory>();

        if(inventoryItems.Count > 0)
        {
            foreach (Note item in inventoryItems)
                playerInventory.AddItemToInventory(item);

            inventoryItems.Clear();
        }
    }

}
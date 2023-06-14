//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Progress;

public class ObjectInventory : MonoBehaviour
{
    public List<NoteItem> inventoryItems = new List<NoteItem>();

    public void AddItemsToInventory(List<NoteItem> newItems)
    {
        inventoryItems.AddRange(newItems);
    }

    public void TransferItemsToPlayer()
    {
        PlayerInventory playerInventory = FindObjectOfType<PlayerInventory>();

        if(inventoryItems.Count > 0)
        {
            foreach (NoteItem item in inventoryItems)
                playerInventory.AddItemToInventory(item);

            inventoryItems.Clear();
        }
    }

}
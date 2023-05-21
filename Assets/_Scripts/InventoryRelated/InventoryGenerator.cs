using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class InventoryGenerator : MonoBehaviour
{
    [SerializeField] Transform roomsContent;
    [SerializeField] List<Item> allItems;

    public void Initialize()
    {
        SetPlayerInventory();
        SetEnemyInventories();
        SetObjectInventories();
    }

    private void SetPlayerInventory()
    {
        PlayerInventory playerInventory = FindObjectOfType<PlayerInventory>();

        foreach(Item item in allItems)
            playerInventory.AddItemToInventory(item);
    }

    private void SetEnemyInventories()
    {
        //throw new NotImplementedException();
    }

    private void SetObjectInventories()
    {
        ObjectInventory[] objectInventories = roomsContent.GetComponentsInChildren<ObjectInventory>();

        foreach (ObjectInventory objectInventory in objectInventories)
        {
            objectInventory.AddItemsToInventory(allItems);
        }
    }
}

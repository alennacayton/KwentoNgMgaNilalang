using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        playerInventory.AddItemsToInventory(allItems);
    }

    private void SetEnemyInventories()
    {
        //throw new NotImplementedException();
    }

    private void SetObjectInventories()
    {
        ObjectInventory[] objectInventories = roomsContent.GetComponentsInChildren<ObjectInventory>();

        foreach(ObjectInventory objectInventory in objectInventories)
        {
            objectInventory.AddItemsToInventory(allItems);
        }
    }
}

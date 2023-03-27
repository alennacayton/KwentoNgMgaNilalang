using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<Item> inventoryItems = new List<Item>();

    public void AddItemsToInventory(List<Item> newItems)
    {
        inventoryItems.AddRange(newItems);

        Debug.Log("Items Successfully Added");
    }

}

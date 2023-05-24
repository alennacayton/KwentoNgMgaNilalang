using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCanvas : MonoBehaviour
{

    List<Slot> itemSlots = new List<Slot>();
    PlayerInventory playerInventory;
    Item toAdd;

    private void Awake()
    {
        itemSlots.AddRange(GetComponentsInChildren<Slot>());
        playerInventory = FindObjectOfType<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < playerInventory.GetInventoryCapacity(); i++)
        {
            toAdd = playerInventory.GetInventoryItemAtIndex(i);
            itemSlots[i].AddItem(toAdd);
        }
    }
}

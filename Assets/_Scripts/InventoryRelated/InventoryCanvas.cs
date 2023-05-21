using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCanvas : MonoBehaviour
{

    List<Slot> itemSlots = new List<Slot>();
    PlayerInventory playerInventory;
    private void Awake()
    {
        itemSlots.AddRange(GetComponentsInChildren<Slot>());
        playerInventory = FindObjectOfType<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        Item toAdd;

        for(int i = 0; i < itemSlots.Count; i++)
        {
            toAdd = playerInventory.GetInventoryItemAtIndex(i);

            if (toAdd != null)
                itemSlots[i].AddItem(toAdd);
        }
    }
}

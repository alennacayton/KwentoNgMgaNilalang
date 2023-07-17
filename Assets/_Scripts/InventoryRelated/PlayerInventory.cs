using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private int capacity = 12;
    [SerializeField] private List<Item> inventoryItems = new List<Item>();

    private InventoryCanvas inventoryCanvas;

    private void Awake()
    {
        inventoryCanvas = FindObjectOfType<InventoryCanvas>();
    }

    public void AddItemToInventory(Item newItem)
    {
        inventoryItems.Add(newItem);
        inventoryCanvas.UpdateInventory();
    }

    public void RemoveItemFromInventory(int index)
    {
        inventoryItems.RemoveAt(index);
        inventoryCanvas.UpdateInventory();
    }

    public Item GetInventoryItemAtIndex(int index)
    {
        return inventoryItems[index];
    }

    public int GetInventoryCapacity()
    {
        return inventoryItems.Count;
    }

    public bool HasQuestItem()
    {
        foreach (Item item in inventoryItems)
        {
            if (item is QuestItem)
            {
                return true;
            }
        }

        return false;
    }

    public int GetNoteItemCount()
    {
        int noteItemCount = 0;

        foreach (Item item in inventoryItems)
        {
            if (item is NoteItem)
            {
                noteItemCount++;
            }
        }

        return noteItemCount;

    }

}
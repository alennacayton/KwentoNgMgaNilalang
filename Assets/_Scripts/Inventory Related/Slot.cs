using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    Image currentItemDisplay;
    Button button;

    [SerializeField] int slotIndex;
    [SerializeField] Item currentItem;

    public void Awake()
    {
        currentItemDisplay = GetComponentInChildren<Image>();
        button = GetComponent<Button>();
        button.enabled = false;
        RemoveItem();
        
        //Debug.Log("Item #" + slotIndex + " has been created and item removed");
    }

    public void AddItem(Item item)
    {
        RemoveItem();

        currentItem = item;
       
        currentItemDisplay.sprite = item.itemSprite;
        currentItemDisplay.enabled = true;

        button.enabled = true;

        button.onClick.AddListener(UseItem);
    }

    public void RemoveItem()
    {
        currentItemDisplay.enabled = false;
        currentItemDisplay.sprite = null;
        currentItem = null;

        button.enabled = false;
        button.onClick.RemoveListener(UseItem);
    }

    public void UseItem()
    {
        currentItem.Use();
        RemoveItem();
        //FindObjectOfType<PlayerInventory>().RemoveItemFromInventory(slotIndex);
    }

}

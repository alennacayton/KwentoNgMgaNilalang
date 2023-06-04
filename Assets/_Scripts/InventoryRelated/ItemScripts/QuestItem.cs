using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest Item")]
public class QuestItem : Item
{
    [SerializeField] Sprite sprite;
    [SerializeField] string nameOfItem;

    [TextArea(20, 20)]
    [SerializeField] string message;

    public override string itemMessage { set => message = value; get { return message; } }
    public override Sprite itemSprite { set => sprite = value; get { return sprite; } }
    public override string itemName { set => nameOfItem = value; get { return nameOfItem; } }

    public override void Use()
    {
        /*
        PlayerInventory playerInventory = FindObjectOfType<PlayerInventory>();
        playerInventory.AddItemToInventory(this);
        */
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest Item")]
public class QuestItem : Item
{
    [SerializeField] Sprite sprite;
    [SerializeField] string nameOfItem;
    public override Sprite itemSprite { get { return sprite; }  set => sprite = value; }
    public override string itemName { get { return nameOfItem; } set => nameOfItem = value; }

    public override void Use()
    {
        Debug.Log("Quest Item Has Been Used");
    }
}

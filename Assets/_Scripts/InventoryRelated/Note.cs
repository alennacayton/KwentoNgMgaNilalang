using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(menuName = "Note")]
public class Note : Item
{

    [SerializeField] Sprite sprite;
    [SerializeField] string nameOfItem;

    [TextArea(20,20)]
    [SerializeField] string message;

    public override Sprite itemSprite { get { return sprite; } set => sprite = value;  }
    public override string itemName { get { return nameOfItem; } set => nameOfItem = value; }


    public override void Use()
    {
        NotePanel noteText = FindObjectOfType<NotePanel>();

        noteText.SetText(message);
        noteText.ShowNote();

        FindObjectOfType<InventoryButtonManager>().ButtonPressed();

        //Debug.Log("HELLO WORLD. THIS SLOT HAS BEEN USED \n");
    }
}

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

    public override Sprite itemSprite { set => sprite = value; get { return sprite; } }
    public override string itemName { set => nameOfItem = value; get { return nameOfItem;  } }

    public override void Use()
    {
        NotePanel noteText = FindObjectOfType<NotePanel>();

        noteText.SetText(message);
        noteText.ShowNote();

        FindObjectOfType<InventoryButtonManager>().ButtonPressed();

        Debug.Log("HELLO WORLD. THIS SLOT HAS BEEN USED \n");
    }
}

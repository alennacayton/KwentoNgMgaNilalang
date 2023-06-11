using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(menuName = "Note Item")]
public class NoteItem : Item
{

    [SerializeField] Sprite sprite;
    [SerializeField] string nameOfItem;

    [TextArea(20,20)]
    [SerializeField] string message;
    [SerializeField] private int tag;

    public int Tag
    {
        get => tag;
        set => tag = value;
    }
   
    public override string itemMessage { set => message = value; get { return message; } }
    public override Sprite itemSprite { set => sprite = value; get { return sprite; } }
    public override string itemName { set => nameOfItem = value; get { return nameOfItem;  } }

    public override void Use()
    {
        NotePanel noteText = FindObjectOfType<NotePanel>();

        noteText.SetText(message);
        noteText.ShowNote();


        FindObjectOfType<AlmanacContent>().AddDescription(message);
        FindObjectOfType<InventoryButtonManager>().ButtonPressed();

        Debug.Log("HELLO WORLD. THIS SLOT HAS BEEN USED \n");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestScript : MonoBehaviour
{
    private bool isInRange;
    private bool isOpen;

    [SerializeField] private float triggerRadius = 1.5f;
    [SerializeField] private KeyCode interactKey;
    [SerializeField] private Sprite chestClosed;
    [SerializeField] private Sprite chestOpen;

    private SpriteRenderer spriteRenderer;

    private Image noteImg;
    private Text noteTxt;

    public Note note;



    // Start is called before the first frame update
    private void Start()
    {
        isOpen = false;
        isInRange = false;
        interactKey = KeyCode.E;
        GetComponent<CircleCollider2D>().radius = triggerRadius;

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = chestClosed;

        // Get a reference to the GameObject
        GameObject myObject = GameObject.Find("Note");
        GameObject myObjectText = GameObject.Find("NoteText");

        // Get a reference to the Image component on the GameObject
        noteImg = myObject.GetComponent<Image>();
        noteTxt = myObjectText.GetComponent<Text>();
    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(interactKey))
        {
            //Debug.Log("Item has been interacted with!!!");
            isOpen = !isOpen;

            if (isOpen)
            {
                spriteRenderer.sprite = chestOpen;
                //Debug.Log("Chest has been opened!!");

                noteTxt.text = note.message;
                noteImg.enabled = true;
                noteTxt.enabled = true;

                Debug.Log("Note Title: " + note.title);
                Debug.Log("Note Message: " + note.message);

            }
            else
            {
                spriteRenderer.sprite = chestClosed;
                //Debug.Log("Chest has been closed!!");
                noteImg.enabled = false;
                noteTxt.enabled = false;
            }
        }


    }

    public void SetNoteObject(Note noteObject)
    {
        note = noteObject;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Item is In Range");
        isInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("Item is Out of Range");
        isInRange = false;

        noteImg.enabled = false;
        noteTxt.enabled = false;
    }


}
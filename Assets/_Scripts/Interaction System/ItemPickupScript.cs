using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickupScript : MonoBehaviour
{
    private bool isInRange;
    private bool isPickedUp;

    [SerializeField] private float triggerRadius = 1.5f;
    [SerializeField] private KeyCode interactKey;
    [SerializeField] private Sprite sprite1;
    [SerializeField] private Sprite sprite2;
    [SerializeField] private Item item;
    [SerializeField] bool isChest;

    private SpriteRenderer spriteRenderer;
    private PlayerInventory playerInventory;
    

    // Start is called before the first frame update
    private void Awake()
    {
        isPickedUp = false;
        isInRange = false;
        interactKey = KeyCode.E;
        GetComponent<CircleCollider2D>().radius = triggerRadius;

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite1;

        playerInventory = FindObjectOfType<PlayerInventory>();
    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(interactKey) && !isPickedUp)
        {
            isPickedUp = true;

            if(item != null)
            {
                playerInventory.AddItemToInventory(item);
                item = null;
            }
<<<<<<< HEAD:Assets/_Scripts/Interaction System/ItemPickupScript.cs

            if (isChest)
                spriteRenderer.sprite = sprite2;
            else Destroy(gameObject);


=======
>>>>>>> parent of 5c132c8 (Displays note when chest is clicked):Assets/_Scripts/Interaction System/ChestScript.cs
        }
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
    }


}
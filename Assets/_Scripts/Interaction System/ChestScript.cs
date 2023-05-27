using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestScript : MonoBehaviour
{
    private bool isInRange;
    private bool isOpened;

    [SerializeField] private float triggerRadius = 1.5f;
    [SerializeField] private KeyCode interactKey;
    [SerializeField] private Sprite chestClosed;
    [SerializeField] private Sprite chestOpen;
    [SerializeField] private Item item;

    private SpriteRenderer spriteRenderer;
    private PlayerInventory playerInventory;
    

    // Start is called before the first frame update
    private void Awake()
    {
        isOpened = false;
        isInRange = false;
        interactKey = KeyCode.E;
        GetComponent<CircleCollider2D>().radius = triggerRadius;

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = chestClosed;

        playerInventory = FindObjectOfType<PlayerInventory>();
    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(interactKey) && !isOpened)
        {
            isOpened = true;
            spriteRenderer.sprite = chestOpen;

            if(item != null)
            {
                playerInventory.AddItemToInventory(item);
                item = null;
            }
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    private bool isInRange;
    private bool isOpen;

    [SerializeField] private float triggerRadius = 1.5f;
    [SerializeField] private KeyCode interactKey;
    [SerializeField] private Sprite chestClosed;
    [SerializeField] private Sprite chestOpen;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    private void Start()
    {
        isOpen = false;
        isInRange = false;
        interactKey = KeyCode.E;
        GetComponent<CircleCollider2D>().radius = triggerRadius;

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = chestClosed;
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
                Debug.Log("Chest has been opened!!");
            }
            else
            {
                spriteRenderer.sprite = chestClosed;
                Debug.Log("Chest has been closed!!");
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

using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Object : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private BoxCollider2D itemCollider;

    [SerializeField]
    bool nonDestructible;

    [SerializeField]
    private GameObject hitFeedback, destoyFeedback;

    [SerializeField]
    private bool interactable;

    [SerializeField]
    public UnityEvent OnInteract;

    [SerializeField] public KeyCode interactKey;

    [SerializeField] Item pickupItem;

    private void Awake()
    {
        interactKey = FindObjectOfType<GameManager>().interactKey; 
    }
    public void Initialize(ObjectData itemData)
    {

        //set sprite
        spriteRenderer.sprite = itemData.sprite;
        //set sprite offset
        spriteRenderer.transform.localPosition = new Vector2(0.5f * itemData.size.x, 0.5f * itemData.size.y);
        itemCollider.size = itemData.size;
        itemCollider.offset = spriteRenderer.transform.localPosition;

        nonDestructible = itemData.nonDestructible;
        interactable = itemData.interactable;
        OnInteract = itemData.OnInteract;
        pickupItem = itemData.pickupItem;

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKeyDown(interactKey) && interactable){
            PickUpItem();
        }
    }

    public void PickUpItem()
    {
        PlayerInventory playerInventory = FindObjectOfType<PlayerInventory>();
        playerInventory.AddItemToInventory(pickupItem);
        FindObjectOfType<SoundEffects>().PlayPickupItem();
        Destroy(this.gameObject);
    }
}


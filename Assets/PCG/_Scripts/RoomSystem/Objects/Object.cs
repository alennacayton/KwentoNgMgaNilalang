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


    public void Initialize(ObjectData itemData)
    {
        //set sprite
        spriteRenderer.sprite = itemData.sprite;
        //set sprite offset
        spriteRenderer.transform.localPosition = new Vector2(0.5f * itemData.size.x, 0.5f * itemData.size.y);
        itemCollider.size = itemData.size;
        itemCollider.offset = spriteRenderer.transform.localPosition;

        if (itemData.nonDestructible)
            this.nonDestructible = true;

        if (itemData.interactable)
            this.interactable = true;

        if (itemData.OnInteract != null)
            this.OnInteract = itemData.OnInteract;
    }





    public void TransferItems()
    {
        ObjectInventory itemInventory = GetComponent<ObjectInventory>();
        itemInventory.TransferItemsToPlayer();

        Debug.Log("Transferred To Player");
    }
}


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
    int health = 3;
    [SerializeField]
    bool nonDestructible;

    [SerializeField]
    private GameObject hitFeedback, destoyFeedback;

    [SerializeField]
    private bool interactable;

    [SerializeField]
    public UnityEvent OnInteract;

    public UnityEvent OnGetHit { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

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

        this.health = itemData.health;

        if (itemData.interactable)
            this.interactable = true;

        if (itemData.OnInteract != null)
            this.OnInteract = itemData.OnInteract;
    }

    public void GetHit(int damage, GameObject damageDealer)
    {
        if (nonDestructible)
            return;
        if(health>1)
            Instantiate(hitFeedback, spriteRenderer.transform.position, Quaternion.identity);
        else
            Instantiate(destoyFeedback, spriteRenderer.transform.position, Quaternion.identity);
        spriteRenderer.transform.DOShakePosition(0.2f, 0.3f, 75, 1, false, true).OnComplete(ReduceHealth);
    }

    private void ReduceHealth()
    {
        health--;
        if (health <= 0)
        {
            spriteRenderer.transform.DOComplete();
            Destroy(gameObject);
        }
    }

    public void TransferItems()
    {
        ObjectInventory itemInventory = GetComponent<ObjectInventory>();
        itemInventory.TransferItemsToPlayer();

        Debug.Log("Transferred To Player");
    }
}


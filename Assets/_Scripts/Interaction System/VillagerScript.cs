using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerScript : MonoBehaviour
{

    public bool isInRange;
    // Start is called before the first frame update
    [SerializeField] private float triggerRadius = 1.5f;
    [SerializeField] private KeyCode interactKey;


    public void Start()
    {
        isInRange = false;
        interactKey = KeyCode.E;
        GetComponent<CircleCollider2D>().radius = triggerRadius;
    }

    // Update is called once per frame
    public void Update()
    {
        if (isInRange && Input.GetKeyDown(interactKey))
        {
            Debug.Log("Hello There Young Man!!!");

        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Item is In Range");
        isInRange = true;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("Item is Out of Range");
        isInRange = false;
    }
}
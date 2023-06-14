using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private KeyCode interactKey;

    public AudioSource movementSoundEffect;

    public UnityEvent<Vector2> OnMovementInput;


    //[SerializeField]
    //private InputActionReference movement, attack, pointerPosition;
    private Object currentlyInteractableObject;

    private void Awake()
    {
        interactKey = FindObjectOfType<GameManager>().interactKey;
    }

    private void Update()
    {
        //OnMovementInput?.Invoke(movement.action.ReadValue<Vector2>().normalized);
        OnMovementInput?.Invoke(new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical")));
        if(Input.GetKey(KeyCode.W) ||Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            movementSoundEffect.enabled = true;
        }
        else
        {
            movementSoundEffect.enabled = false;
        }
        /*
        if(Input.GetKeyDown(interactKey))
        {
            Debug.Log("Key E is Down");
            currentlyInteractableObject.OnInteract?.Invoke();
        }

        */

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Object")
        {
            this.currentlyInteractableObject = collision.collider.gameObject.GetComponent<Object>();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        this.currentlyInteractableObject = null;
    }

    //private void OnEnable()
    //{
    //    attack.action.performed += PerformAttack;
    //}

    //private void PerformAttack(InputAction.CallbackContext obj)
    //{
    //    OnAttack?.Invoke();
    //}

    //private void OnDisable()
    //{
    //    attack.action.performed -= PerformAttack;
    //}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private KeyCode interactKey;

    public UnityEvent<Vector2> OnMovementInput, OnPointerInput;
    public UnityEvent OnAttack;

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
        OnPointerInput?.Invoke(GetPointerInput());
        if(Input.GetMouseButtonDown(0))
            OnAttack?.Invoke();



        /*
        if(Input.GetKeyDown(interactKey))
        {
            Debug.Log("Key E is Down");
            currentlyInteractableObject.OnInteract?.Invoke();
        }

        */

    }

    private Vector2 GetPointerInput()
    {
        //Vector3 mousePos = pointerPosition.action.ReadValue<Vector2>();
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
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

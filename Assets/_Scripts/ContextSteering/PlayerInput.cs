using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private KeyCode interActKey = KeyCode.E;

    public UnityEvent<Vector2> OnMovementInput, OnPointerInput;
    public UnityEvent OnAttack;
    public UnityEvent<Item> OnInteract;

    //[SerializeField]
    //private InputActionReference movement, attack, pointerPosition;
    private Item currentlyInteractedItem;


    private void Update()
    {
        //OnMovementInput?.Invoke(movement.action.ReadValue<Vector2>().normalized);
        OnMovementInput?.Invoke(new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical")));
        OnPointerInput?.Invoke(GetPointerInput());
        if(Input.GetMouseButtonDown(0))
            OnAttack?.Invoke();

        if (Input.GetKeyDown(interActKey))
        {
            OnInteract?.Invoke(currentlyInteractedItem);
        }
    }

    private Vector2 GetPointerInput()
    {
        //Vector3 mousePos = pointerPosition.action.ReadValue<Vector2>();
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    public void SetInteractedItem(Item item)
    {
        currentlyInteractedItem = item;
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

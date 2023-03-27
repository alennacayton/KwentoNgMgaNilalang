using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu()]
public class Item : ScriptableObject
{
    [SerializeField] Sprite spriteInInventory, spriteInGame;
    [SerializeField] string itemName;
    [SerializeField] UnityEvent behavior;
}

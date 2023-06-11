using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;


public abstract class Item: ScriptableObject
{
    public abstract Sprite itemSprite { get;  set; }
    public abstract string itemName { get;  set; }
    public abstract void Use();
    public virtual int Tag { get; protected set; }
    public abstract string itemMessage { get; set; }
}

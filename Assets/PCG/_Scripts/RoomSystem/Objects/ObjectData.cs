using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class ObjectData : ScriptableObject
{
    public Sprite sprite;
    public Vector2Int size = new Vector2Int(1, 1);
    public PlacementType placementType;
    public bool addOffset;
    public int health = 1;
    public bool nonDestructible;
    public bool interactable;
    public UnityEvent OnInteract;
}

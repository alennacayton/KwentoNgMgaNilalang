using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DefaultRoom : RoomGenerator
{
    [SerializeField]
    private PrefabPlacer prefabPlacer;

    public List<ObjectPlacementData> itemData;

    public override List<GameObject> ProcessRoom(Vector2Int roomCenter, HashSet<Vector2Int> roomFloor, HashSet<Vector2Int> roomFloorNoCorridors)
    {
        ObjectPlacementHelper itemPlacementHelper =
            new ObjectPlacementHelper(roomFloor, roomFloorNoCorridors);

        List<GameObject> placedObjects =
            prefabPlacer.PlaceAllItems(itemData, itemPlacementHelper);


        return placedObjects;
    }
}

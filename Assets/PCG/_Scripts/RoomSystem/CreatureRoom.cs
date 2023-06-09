using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureRoom : RoomGenerator
{
    [SerializeField]
    private PrefabPlacer prefabPlacer;

    public List<ObjectPlacementData> itemData;

    public override List<GameObject> ProcessRoom(Vector2Int roomCenter, HashSet<Vector2Int> roomFloor, HashSet<Vector2Int> roomFloorNoCorridors)
    {
        Debug.Log("Test");

        ObjectPlacementHelper itemPlacementHelper =
            new ObjectPlacementHelper(roomFloor, roomFloorNoCorridors);

        List<GameObject> placedObjects =
            prefabPlacer.PlaceAllItems(itemData, itemPlacementHelper);


        return placedObjects;
    }
}

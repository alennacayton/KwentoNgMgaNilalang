using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class PrefabPlacer : MonoBehaviour
{
    [SerializeField]
    private GameObject objectPrefab;

    public List<GameObject> PlaceAllItems(List<ObjectPlacementData> itemPlacementData, ObjectPlacementHelper itemPlacementHelper)
    {
        List<GameObject> placedObjects = new List<GameObject>();

        IEnumerable<ObjectPlacementData> sortedList = new List<ObjectPlacementData>(itemPlacementData).OrderByDescending(placementData => placementData.objectData.size.x * placementData.objectData.size.y);
        foreach (var placementData in sortedList)
        {
            for (int i = 0; i < placementData.Quantity; i++)
            {
                Vector2? possiblePlacementSpot = itemPlacementHelper.GetItemPlacementPosition(
                    placementData.objectData.placementType, 
                    100, 
                    placementData.objectData.size, 
                    placementData.objectData.addOffset);


                if (possiblePlacementSpot.HasValue)
                {

                    placedObjects.Add(PlaceItem(placementData.objectData, possiblePlacementSpot.Value));
                }
            }
        }
        return placedObjects;
    }
    private GameObject PlaceItem(ObjectData item, Vector2 placementPosition)
    {
        GameObject newItem = CreateObject(objectPrefab,placementPosition);
        //GameObject newItem = Instantiate(itemPrefab, placementPosition, Quaternion.identity);
        newItem.GetComponent<Object>().Initialize(item);
        return newItem;
    }

    public GameObject CreateObject(GameObject prefab, Vector3 placementPosition)
    {
        if (prefab == null)
            return null;
        GameObject newItem;
        if (Application.isPlaying)
        {
            newItem = Instantiate(prefab, placementPosition, Quaternion.identity);
        }
        else
        {
            newItem = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
            newItem.transform.position = placementPosition;
            newItem.transform.rotation = Quaternion.identity;
        }

        return newItem;
    }
}

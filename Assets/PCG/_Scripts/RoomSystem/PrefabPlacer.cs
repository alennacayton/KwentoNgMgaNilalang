using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrefabPlacer : MonoBehaviour
{
    [SerializeField]
    private GameObject objectPrefab;

    [SerializeField]
    private List<SceneNotes> sceneNotes; // List of SceneNotes objects for each scene


    private void Awake()
    {
      
        // Reset the tag values to 0
        foreach (var sceneNote in sceneNotes)
        {
            foreach (var note in sceneNote.notes)
            {
                note.Tag = 0;
                UnityEditor.EditorUtility.SetDirty(note);
            }
        }

        UnityEditor.AssetDatabase.SaveAssets();

        
    }

    public List<GameObject> PlaceInteractableObject(List<PrefabPlacementData> objectPlacementData, ObjectPlacementHelper itemPlacementHelper)
    {
        List<GameObject> placedObjects = new List<GameObject>();

        foreach (var placementData in objectPlacementData)
        {
            for (int i = 0; i < placementData.Quantity; i++)
            {
                Vector2? possiblePlacementSpot = itemPlacementHelper.GetItemPlacementPosition(
                    PlacementType.OpenSpace,
                    100,
                    placementData.objectSize,
                    false
                    );
                if (possiblePlacementSpot.HasValue)
                {

                    placedObjects.Add(CreateObject(placementData.objectPrefab, possiblePlacementSpot.Value + new Vector2(0.5f, 0.5f)));
                }
            }
        }
        return placedObjects;
    }



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
        GameObject newItem = null;
        if (Application.isPlaying)
        {

            // Check if prefab is a Chest

            if (prefab.name == "Chest")
            {

                SceneNotes sceneNote = sceneNotes.Find(x => x.sceneName == SceneManager.GetActiveScene().name);

                if (sceneNote == null)
                {
                    Debug.LogError("No SceneNotes found for scene: " + SceneManager.GetActiveScene().name);
                }


                // Generate the Chest prefab
                GameObject newChest = Instantiate(prefab, placementPosition, Quaternion.identity);

                ChestScript chestComponent = newChest.GetComponent<ChestScript>();

                Note selectedNote = null;

                foreach (var note in sceneNote.notes)
                {
                    if (note.Tag == 0)
                    {
                        selectedNote = note;

                        note.Tag = 1;

                        UnityEditor.EditorUtility.SetDirty(note);
                        UnityEditor.AssetDatabase.SaveAssets();
                        break;
                    }
                    Debug.Log("Note: " + note);
                }

                chestComponent.SetNoteObject(selectedNote);


            }
            else
            {
                newItem = Instantiate(prefab, placementPosition, Quaternion.identity);
            }


        }
        else
        {

            newItem = Instantiate(prefab, placementPosition, Quaternion.identity);
        }



        return newItem;
    }
}
[System.Serializable]
public class SceneNotes
{
    public string sceneName;
    public Note[] notes;
}
using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class RoomContentGenerator : MonoBehaviour
{
    [SerializeField]
    private RoomGenerator playerRoom, defaultRoom, creatureRoom, questRoom, diwataRoom, bungisngisRoom, pugotRoom;

    List<GameObject> spawnedObjects = new List<GameObject>();

    [SerializeField]
    private GraphTest graphTest;


    public Transform itemParent;

    [SerializeField]
    private CinemachineVirtualCamera cinemachineCamera;

    public UnityEvent RegenerateDungeon;

    public Vector2Int playerSpawn = new Vector2Int(0, 0);

    public void GenerateRoomContent(DungeonData dungeonData)
    {
      
        foreach (GameObject item in spawnedObjects)
        {
            DestroyImmediate(item);
        }
        spawnedObjects.Clear();

        SelectPlayerSpawnPoint(dungeonData);
        SelectBossSpawnPoint(dungeonData);
        SelectQuestRooms(dungeonData);
        SelectEnemySpawnPoints(dungeonData);

        foreach (GameObject item in spawnedObjects)
        {
            if (item != null)
                item.transform.SetParent(itemParent, false);
        }

        //FindObjectOfType<InventoryGenerator>().Initialize();
    }

    // Selects random room as player spawn point
    private void SelectPlayerSpawnPoint(DungeonData dungeonData)
    {
        int randomRoomIndex = UnityEngine.Random.Range(0, dungeonData.roomsDictionary.Count);
        Vector2Int playerSpawnPoint = dungeonData.roomsDictionary.Keys.ElementAt(randomRoomIndex);

        playerSpawn = playerSpawnPoint;

        // running algo from player spawn point
        graphTest.RunDijkstraAlgorithm(playerSpawnPoint, dungeonData.floorPositions);

        
        Vector2Int roomIndex = dungeonData.roomsDictionary.Keys.ElementAt(randomRoomIndex);
   

        // creating player room
        List<GameObject> placedPrefabs = playerRoom.ProcessRoom(
            playerSpawnPoint,
            dungeonData.roomsDictionary.Values.ElementAt(randomRoomIndex),
            dungeonData.GetRoomFloorWithoutCorridors(roomIndex)
            );

        FocusCameraOnThePlayer(placedPrefabs[placedPrefabs.Count - 1].transform);

        // spawnedObjects : stores all objects inside rooms
        spawnedObjects.AddRange(placedPrefabs);

        dungeonData.roomsDictionary.Remove(playerSpawnPoint);
    }

    private void FocusCameraOnThePlayer(Transform playerTransform)
    {
        cinemachineCamera.LookAt = playerTransform;
        cinemachineCamera.Follow = playerTransform;
    }



    private void SelectBossSpawnPoint(DungeonData dungeonData)
    {

        checkRoomsEmpty(dungeonData);
   


        // ================================= USING DIJKSTRA ALGO =================================================




        //Coordinates of highest point

        Vector2Int highestPoint = new Vector2Int(0, 0);
        Vector2Int bossRoomKey = new Vector2Int(0, 0);
        HashSet<Vector2Int> bossRoomValues = new HashSet<Vector2Int>();


        foreach (var result in graphTest.getDijkstraResult().Reverse())
        {

            if (!isCorridor(result.Key, dungeonData)) // If not a corridor, set it to highest key
            {
                Debug.Log("Highest Key : " + highestPoint);
                highestPoint = result.Key;
                goto proceed;

            }

        }

        proceed:
        foreach (KeyValuePair<Vector2Int, HashSet<Vector2Int>> roomData in dungeonData.roomsDictionary)
        {
      
           foreach (var val in dungeonData.GetRoomFloorWithoutCorridors(roomData.Key))
           {
                if (val.Equals(highestPoint))
                {
                    bossRoomKey = roomData.Key;
                    bossRoomValues = roomData.Value;
                }
            }


        }



        Debug.Log("=========================================================   BOSS ROOM KEY " + bossRoomKey + " =========================================================");


        if (SceneManager.GetActiveScene().name.Equals("AreaOne")){
            spawnedObjects.AddRange(
             creatureRoom.ProcessRoom(
                 bossRoomKey,
                 bossRoomValues,
                 dungeonData.GetRoomFloorWithoutCorridors(bossRoomKey))
            );
        } else if (SceneManager.GetActiveScene().name.Equals("AreaTwo"))
        {
            spawnedObjects.AddRange(
            diwataRoom.ProcessRoom(
                bossRoomKey,
                bossRoomValues,
                dungeonData.GetRoomFloorWithoutCorridors(bossRoomKey))
           );
        } else if (SceneManager.GetActiveScene().name.Equals("AreaThree"))
        {
            spawnedObjects.AddRange(
            pugotRoom.ProcessRoom(
                bossRoomKey,
                bossRoomValues,
                dungeonData.GetRoomFloorWithoutCorridors(bossRoomKey))
           );
        } else if (SceneManager.GetActiveScene().name.Equals("AreaFour"))
        {
            spawnedObjects.AddRange(
               bungisngisRoom.ProcessRoom(
                   bossRoomKey,
                   bossRoomValues,
                   dungeonData.GetRoomFloorWithoutCorridors(bossRoomKey))
              );
        }


   


        // remove room from list
        dungeonData.roomsDictionary.Remove(bossRoomKey);
        
    }

    // Checks if key is a corridor
    private Boolean isCorridor(Vector2Int key, DungeonData dungeonData)
    {


        foreach (KeyValuePair<Vector2Int, HashSet<Vector2Int>> roomData in dungeonData.roomsDictionary)
        {
            
            foreach (var val in dungeonData.GetRoomFloorWithoutCorridors(roomData.Key)) // NO CORRIDORS
            {
       
                if (key.Equals(val)) 
                {
                    Debug.Log("=========== KEY IN ROOMS ===============");
                    return false;
                }
            }

        }

        return true;
    }



    private void SelectQuestRooms(DungeonData dungeonData)
    {
        checkRoomsEmpty(dungeonData);
        // Assigns first 3 rooms as quest rooms
        HashSet<Vector2Int> temp = new HashSet<Vector2Int>(3); // keys to remove



        for (int i = 0; i < 3; i++)
        {
            KeyValuePair<Vector2Int, HashSet<Vector2Int>> roomData = dungeonData.roomsDictionary.ElementAt(i);
            spawnedObjects.AddRange(
                questRoom.ProcessRoom(
                    roomData.Key,
                    roomData.Value,
                    dungeonData.GetRoomFloorWithoutCorridors(roomData.Key)
                )
            );


            temp.Add(roomData.Key);
            
        }




        foreach (Vector2Int key in temp)
        {
            if (dungeonData.roomsDictionary.ContainsKey(key))
            {
                dungeonData.roomsDictionary.Remove(key);
            }
        }




    }




    private void SelectEnemySpawnPoints(DungeonData dungeonData)
    {
        checkRoomsEmpty(dungeonData);
        // creating the rest of the rooms

        foreach (KeyValuePair<Vector2Int,HashSet<Vector2Int>> roomData in dungeonData.roomsDictionary)
        { 

            spawnedObjects.AddRange(
                defaultRoom.ProcessRoom(
                    roomData.Key,
                    roomData.Value, 
                    dungeonData.GetRoomFloorWithoutCorridors(roomData.Key)
                    )
            );

        }
    }


    private void checkRoomsEmpty(DungeonData dungeonData)
    {
        if (dungeonData.roomsDictionary.Equals(null))
        {
            throw new Exception("Room Dictionary is NULL");

        }
    }


}

using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class RoomContentGenerator : MonoBehaviour
{
    [SerializeField]
    private RoomGenerator playerRoom, defaultRoom, creatureRoom;

    List<GameObject> spawnedObjects = new List<GameObject>();

    [SerializeField]
    private GraphTest graphTest;


    public Transform itemParent;

    [SerializeField]
    private CinemachineVirtualCamera cinemachineCamera;

    public UnityEvent RegenerateDungeon;

    public Vector2Int playerSpawn = new Vector2Int(0, 0);

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (var item in spawnedObjects)
            {
                Destroy(item);
            }
            RegenerateDungeon?.Invoke();
        }
    }
    public void GenerateRoomContent(DungeonData dungeonData)
    {
        /*
        // Debug
        foreach (KeyValuePair<Vector2Int, HashSet<Vector2Int>> roomData in dungeonData.roomsDictionary)
        {
            Debug.Log("ROOM Key: " + roomData.Key);

            foreach (var val in roomData.Value)
            {

                Debug.Log(val + "\n");
            }

        }
        Debug.Log(dungeonData.roomsDictionary.Count);





        */

        foreach (GameObject item in spawnedObjects)
        {
            DestroyImmediate(item);
        }
        spawnedObjects.Clear();

        SelectPlayerSpawnPoint(dungeonData);
        SelectBossSpawnPoint(dungeonData);
        SelectEnemySpawnPoints(dungeonData);

        foreach (GameObject item in spawnedObjects)
        {
            if(item != null)
                item.transform.SetParent(itemParent, false);
        }


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

    




        /*


        // ================================= USING DISTANCE BETWEEN POINTS =================================================

        float maxDistance = 0;
        Vector2Int highest = new Vector2Int(0, 0);

        HashSet<Vector2Int> highestRoomValues = new HashSet<Vector2Int>();

        foreach (KeyValuePair<Vector2Int, HashSet<Vector2Int>> roomData in dungeonData.roomsDictionary)
        {
            Debug.Log( "DISTANCE ======================================================================================================== " + Vector2.Distance(playerSpawn, roomData.Key) + " KEY  " + roomData.Key);
             // center of room

            if(Vector2.Distance(playerSpawn, roomData.Key) > maxDistance)
            {
                maxDistance = Vector2.Distance(playerSpawn, roomData.Key);
                highest = roomData.Key;
            }

        }


        foreach (KeyValuePair<Vector2Int, HashSet<Vector2Int>> roomData in dungeonData.roomsDictionary)
        {
            if (roomData.Key.Equals(highest))
            {
                highestRoomValues = roomData.Value;
            }
        }

        spawnedObjects.AddRange(
         creatureRoom.ProcessRoom(
             highest,
             highestRoomValues,
             dungeonData.GetRoomFloorWithoutCorridors(highest))
        );


        dungeonData.roomsDictionary.Remove(highest);






        */






        

        // ================================= USING DIJKSTRA ALGO =================================================




        //Coordinates of highest point

        Vector2Int highestPoint = new Vector2Int(0, 0);
        Vector2Int bossRoomKey = new Vector2Int(0, 0);
        HashSet<Vector2Int> bossRoomValues = new HashSet<Vector2Int>();

     

        foreach (var result in graphTest.getDijkstraResult().Reverse())
        {
            // Debug.Log("Key = " + result.Key + " Value = " + result.Value);

            if (!isCorridor(result.Key, dungeonData)) // IF ITS HIGHEST VALUE AND IS NOT A CORRIDOR SET IT TO HIGHEST
            {
                Debug.Log("Highest Key : " + highestPoint);
                highestPoint = result.Key;
                goto proceed;

            }

        }


        // iterate through all rooms and coordinates
        // locate which room has the highest point
        // set room as boss room

        proceed:
        foreach (KeyValuePair<Vector2Int, HashSet<Vector2Int>> roomData in dungeonData.roomsDictionary)
        {
            // Debug.Log("ROOM Key: " + roomData.Key);


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

        spawnedObjects.AddRange(
          creatureRoom.ProcessRoom(
              bossRoomKey,
              bossRoomValues,
              dungeonData.GetRoomFloorWithoutCorridors(bossRoomKey))
         );


        // remove room  from list
        dungeonData.roomsDictionary.Remove(bossRoomKey);
        
    }


    private Boolean isCorridor(Vector2Int key, DungeonData dungeonData)
    {

        foreach (KeyValuePair<Vector2Int, HashSet<Vector2Int>> roomData in dungeonData.roomsDictionary)
        {
            
            foreach (var val in dungeonData.GetRoomFloorWithoutCorridors(roomData.Key)) // NO CORRIDORS
            {
                // SHOULD BE ROOM KEYS
   
                if (key.Equals(val)) 
                {
                    Debug.Log("=========== KEY IN ROOMS ===============");
                    return false;
                }
            }

        }



        return true;
    }



    private void SelectEnemySpawnPoints(DungeonData dungeonData)
    {
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

}

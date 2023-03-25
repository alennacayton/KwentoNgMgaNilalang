using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GraphTest : MonoBehaviour
{
    Graph graph;

    bool graphReady = false;

    Dictionary<Vector2Int, int> dijkstraResult;
    int highestValue;

    public void RunDijkstraAlgorithm(Vector2Int playerPosition,IEnumerable<Vector2Int> floorPositions)
    {
        graphReady = false;
        graph = new Graph(floorPositions);
        dijkstraResult = DijkstraAlgorithm.Dijkstra(graph, playerPosition);
        highestValue = dijkstraResult.Values.Max();
        Debug.Log("Dijkstra Highest Value: " + highestValue);
        graphReady = true;

        // print dijstra result
        Debug.Log("=================DIJKSTRA RESULT===================");
        foreach (var kvp in dijkstraResult)
        {
            Debug.Log("Key = " + kvp.Key + " Value = " + kvp.Value);
        }
        Debug.Log("=================END===================");

    }


    private void OnDrawGizmosSelected()
    {
        if (graphReady && dijkstraResult != null)
        {
            foreach (var item in dijkstraResult)
            {
                Color color = Color.Lerp(Color.green, Color.red, (float)item.Value / highestValue);
                color.a = 0.5f;
                if (item.Value.Equals(highestValue))
                {
                   // Debug.Log("Highest Val");
                    Gizmos.color = Color.white;
                    Gizmos.DrawCube(item.Key + new Vector2(0.5f, 0.5f), Vector3.one);
                }
                else
                {
                    Gizmos.color = color;
                    Gizmos.DrawCube(item.Key + new Vector2(0.5f, 0.5f), Vector3.one);
                }
               

              
            }
        }
    }

    public int getHighestValue()
    {
        return highestValue;
    }

    public Dictionary<Vector2Int, int> getDijkstraResult()
    {
        return dijkstraResult;
    }

}

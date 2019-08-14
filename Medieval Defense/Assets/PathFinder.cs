using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] private Waypoint startWaypoint, endWaypoint;
    private Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    private Vector2Int[] directions=
    {
        Vector2Int.up, 
        Vector2Int.right, 
        Vector2Int.down, 
        Vector2Int.left
    };
    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
        ExploreNeighbours();
    }

    private void ExploreNeighbours()
    {
        foreach (Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinates = startWaypoint.GetGridPosition() + direction;
            Debug.Log("Exploring: "+ explorationCoordinates);
            try
            {
                grid[explorationCoordinates].SetTopColor(Color.blue);
            }
            catch
            {
                // empty block
            }
        }
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPosition();
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Skipping overlapping block "+waypoint.name);
            }
            else
            {
                grid.Add(gridPos, waypoint);
            }
        }
    }
}

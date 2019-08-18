using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    // public ok here as is a data class
    public bool isExplored = false;
    public Waypoint exploredFrom;
    public bool isPlaceable  = true;

    private Vector2Int gridPosition;
    private const int GridSize = 10;


    public int GetGridSize()
    {
        return GridSize;
    }

    public Vector2Int GetGridPosition()
    {
        return new Vector2Int(Mathf.RoundToInt(transform.position.x / GridSize),
        Mathf.RoundToInt(transform.position.z / GridSize)
        );
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && isPlaceable)
        {
            Debug.Log(gameObject.name);
        }
    }
}

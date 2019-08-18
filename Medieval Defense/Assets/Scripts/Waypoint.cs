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

    [SerializeField] private Tower towerPrefab;

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
            var towerPosition = new Vector3(gameObject.transform.position.x-4f,4.5f,gameObject.transform.position.z-4f);
            Instantiate(towerPrefab,towerPosition,towerPrefab.transform.rotation);
            isPlaceable = false;
            Debug.Log(gameObject.name);
        }
    }
}

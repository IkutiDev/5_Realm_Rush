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
    [SerializeField]private GameObject grassBlock, dirtBlock;


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

    public void ChangeBlockToPath()
    {
        grassBlock.SetActive(false);
        dirtBlock.SetActive(true);
    }
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && isPlaceable)
        {
            FindObjectOfType<TowerFactory>().AddTower(this);
        }
    }
}

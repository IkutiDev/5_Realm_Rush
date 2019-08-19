using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] private int towerLimit = 5;
    [SerializeField] private Tower towerPrefab;
    private Queue towerQueue = new Queue();
    public void AddTower(Waypoint baseWaypoint)
    {
        int currentTowerAmount = towerQueue.Count;
        if (currentTowerAmount < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }
    }

    private void MoveExistingTower(Waypoint baseWaypoint)
    {
        var towerPosition = new Vector3(baseWaypoint.transform.position.x - 4f, 4.5f, baseWaypoint.transform.position.z - 4f);
        var oldTower = towerQueue.Dequeue();
        baseWaypoint.isPlaceable = false;
        //set the placeable flag
        //set the baseWaypoints
        towerQueue.Enqueue(oldTower);
        Debug.Log("Max towers amount reached");
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        var towerPosition = new Vector3(baseWaypoint.transform.position.x - 4f, 4.5f, baseWaypoint.transform.position.z - 4f);
        var newTower =Instantiate(towerPrefab, towerPosition, towerPrefab.transform.rotation);
        newTower.BaseWaypoint = baseWaypoint;
        baseWaypoint.isPlaceable = false;
        towerQueue.Enqueue(newTower);
        Debug.Log(towerQueue.Count);
    }
}

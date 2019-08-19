using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] private int towerLimit = 5;
    [SerializeField] private Tower towerPrefab;
    [SerializeField] private Transform towersParent;
    private Queue<Tower> towerQueue = new Queue<Tower>();
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

    private void MoveExistingTower(Waypoint newBaseWaypoint)
    {
        
        var oldTower = towerQueue.Dequeue();
        oldTower.BaseWaypoint.isPlaceable = true;
        var towerPosition = new Vector3(newBaseWaypoint.transform.position.x - 4f, 4.5f, newBaseWaypoint.transform.position.z - 4f);
        oldTower.transform.position = towerPosition;
        oldTower.BaseWaypoint = newBaseWaypoint;
        newBaseWaypoint.isPlaceable = false;
        towerQueue.Enqueue(oldTower);
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        var towerPosition = new Vector3(baseWaypoint.transform.position.x - 4f, 4.5f, baseWaypoint.transform.position.z - 4f);
        var newTower =Instantiate(towerPrefab, towerPosition, towerPrefab.transform.rotation,towersParent);
        newTower.BaseWaypoint = baseWaypoint;
        baseWaypoint.isPlaceable = false;
        towerQueue.Enqueue(newTower);
    }
}

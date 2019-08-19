using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] private int towerLimit = 5;
    [SerializeField] private Tower towerPrefab;

    private int _currentTowerAmount;
    public void AddTower(Waypoint baseWaypoint, Vector3 towerPosition)
    {
        if (_currentTowerAmount < towerLimit)
        {
            InstantiateNewTower(baseWaypoint, towerPosition);
        }
        else
        {
            MoveExistingTower();
        }
    }

    private static void MoveExistingTower()
    {
        Debug.Log("Max towers amount reached");
    }

    private void InstantiateNewTower(Waypoint baseWaypoint, Vector3 towerPosition)
    {
        Instantiate(towerPrefab, towerPosition, towerPrefab.transform.rotation);
        baseWaypoint.isPlaceable = false;
        _currentTowerAmount++;
    }
}

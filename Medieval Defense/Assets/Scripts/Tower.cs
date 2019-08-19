using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Waypoint BaseWaypoint;
    [SerializeField] private Transform objectToPan;

    [SerializeField] private float attackRange=30f;
    //State
    private Transform targetEnemy;
    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
        objectToPan.LookAt(targetEnemy);
        ShootEnemy(CanShootEnemy());
    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;
        foreach (EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy,testEnemy.transform);
        }

        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform closestEnemy, Transform testEnemyTransform)
    {
        if (CalculateDistanceFromTower(closestEnemy) > CalculateDistanceFromTower(testEnemyTransform))
        {
            return testEnemyTransform;
        }

        return closestEnemy;
    }

    private float CalculateDistanceFromTower(Transform enemyTransform)
    {
        return Vector3.Distance(transform.position, enemyTransform.position);
    }
    private void ShootEnemy(bool canShoot)
    {
        ParticleSystem.EmissionModule towerEmissionModule =
            gameObject.GetComponentInChildren<ParticleSystem>().emission;
        towerEmissionModule.enabled = canShoot;
    }

    private bool CanShootEnemy()
    {
        if (targetEnemy != null)
        {
            float distanceToEnemy = CalculateDistanceFromTower(targetEnemy);
            if (distanceToEnemy<=attackRange)
            {
                return true;
            }
            return false;
        }
        return false;
    }
}

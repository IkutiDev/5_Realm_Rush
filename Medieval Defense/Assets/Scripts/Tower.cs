using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Transform objectToPan;

    [SerializeField] private Transform targetEnemy;

    [SerializeField] private float attackRange=30f;

    private void Start()
    {
        targetEnemy = FindObjectOfType<EnemyMovement>().transform;
        
    }
    // Update is called once per frame
    void Update()
    {
        objectToPan.LookAt(targetEnemy);
        ShootEnemy(CanShootEnemy());
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
            float distanceToEnemy = Vector3.Distance(objectToPan.position, targetEnemy.position);
            if (distanceToEnemy<=attackRange)
            {
                return true;
            }
            return false;
        }
        return false;
    }
}

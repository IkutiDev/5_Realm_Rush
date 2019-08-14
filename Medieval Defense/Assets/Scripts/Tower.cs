using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Transform objectToPan;

    [SerializeField] private Transform targetEnemy;

    private void Start()
    {
        targetEnemy = FindObjectOfType<EnemyMovement>().transform;
    }
    // Update is called once per frame
    void Update()
    {
        objectToPan.LookAt(targetEnemy);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f,120f)]
    [SerializeField] private float secondBetweenSpawnsOrk=5f;

    [SerializeField] private float secondBetweenSpawnsGoblin = 0.5f;
    [SerializeField] private EnemyDamage ork;
    [SerializeField] private EnemyDamage goblin;
    private bool spawnEnemies = true;
    private int orkSpawnCounter;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (spawnEnemies)
        {
            if (orkSpawnCounter >= 5)
            {
                orkSpawnCounter = 0;
                Instantiate(ork, ork.transform.position, ork.transform.rotation,transform);
                yield return new WaitForSeconds(secondBetweenSpawnsOrk);
            }
            else
            {
                orkSpawnCounter++;
                Instantiate(goblin, goblin.transform.position, goblin.transform.rotation, transform);
                yield return new WaitForSeconds(secondBetweenSpawnsGoblin);
            }

        }
    }
}

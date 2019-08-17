using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float secondBetweenSpawns=5f;
    [SerializeField] private Enemy ork;
    [SerializeField] private Enemy goblin;
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
                Instantiate(ork, ork.transform.position, ork.transform.rotation);
                yield return new WaitForSeconds(secondBetweenSpawns);
            }
            else
            {
                orkSpawnCounter++;
                Instantiate(goblin, goblin.transform.position, goblin.transform.rotation);
                yield return new WaitForSeconds(secondBetweenSpawns);
            }

        }
    }
}

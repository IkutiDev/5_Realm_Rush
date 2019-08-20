using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f,120f)]
    [SerializeField] private float secondBetweenSpawnsOrk=5f;
    [Range(0.1f, 120f)]
    [SerializeField] private float secondBetweenSpawnsGoblin = 0.5f;
    [SerializeField] private EnemyDamage ork;
    [SerializeField] private EnemyDamage goblin;
    [SerializeField] private Text scoreText;
    [SerializeField] private AudioClip spawnedEnemySFX;
    private int enemyCounter;
    private int score;
    private bool spawnEnemies = true;

    private void Start()
    {
        scoreText.text = enemyCounter.ToString();
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (spawnEnemies)
        {
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);
            enemyCounter++;
             
            if (enemyCounter%6==0)
            {
                Instantiate(ork, ork.transform.position, ork.transform.rotation,transform);
                score += 5;
                scoreText.text = score.ToString();
                yield return new WaitForSeconds(secondBetweenSpawnsOrk);
            }
            else
            {
                Instantiate(goblin, goblin.transform.position, goblin.transform.rotation, transform);
                score++;
                scoreText.text = score.ToString();
                yield return new WaitForSeconds(secondBetweenSpawnsGoblin);
            }

            
            

        }
    }
}

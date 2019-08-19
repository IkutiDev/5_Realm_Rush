using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float movementPeriod=0.5f;
    [SerializeField] private ParticleSystem reachGoalParticleSystem;
    private void Start()
    {
        PathFinder pathFinder = FindObjectOfType<PathFinder>();
        var path = pathFinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    private IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (var node in path)
        {
            transform.position = node.transform.position;
            yield return new WaitForSeconds(movementPeriod);
        }
        gameObject.GetComponent<EnemyDamage>().KillEnemy(reachGoalParticleSystem);
    }
}

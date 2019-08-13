using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private List<Waypoint> path;

    private void Start()
    {
        StartCoroutine(FollowPath());
    }

    private IEnumerator FollowPath()
    {
        Debug.Log("Starting Patrol...");
        foreach (var node in path)
        {
            Debug.Log("Visiting "+node.name);
            transform.position = node.transform.position;
            yield return new WaitForSeconds(1f);
        }
        Debug.Log("Ending Patrol");
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private int hitPoints=2;
    [SerializeField] private ParticleSystem hitParticlePrefab;
    [SerializeField] private ParticleSystem deathParticleSystem;
    private Transform _deathParticleParent;

    private void Awake()
    {
        _deathParticleParent = GameObject.Find("Particles").transform;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    void ProcessHit()
    {
        hitPoints -= 1;
        hitParticlePrefab.Play();
    }
    private void KillEnemy()
    {
        var vfx =Instantiate(deathParticleSystem, gameObject.transform.position, Quaternion.identity,_deathParticleParent);
        float timeToDestroy = vfx.main.duration;
        Destroy(vfx.gameObject, timeToDestroy);
        Destroy(gameObject);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private int hitPoints=2;
    [SerializeField] private ParticleSystem hitParticlePrefab;
    [SerializeField] private ParticleSystem deathParticleSystem;
    [SerializeField] private AudioClip enemyTakesDamageSFX;
    [SerializeField] private AudioClip enemyDiesSFX;
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
            KillEnemy(deathParticleSystem);
        }
    }

    void ProcessHit()
    {
        hitPoints -= 1;
        hitParticlePrefab.Play();
        //GetComponent<AudioSource>().PlayOneShot(enemyTakesDamageSFX);
    }
    public void KillEnemy(ParticleSystem particleSystem)
    {
        var vfx =Instantiate(particleSystem, gameObject.transform.position, Quaternion.identity,_deathParticleParent);
        AudioSource.PlayClipAtPoint(enemyDiesSFX,Camera.main.transform.position,0.1f);
        float timeToDestroy = vfx.main.duration;
        Destroy(vfx.gameObject, timeToDestroy);
        Destroy(gameObject);
    }
}

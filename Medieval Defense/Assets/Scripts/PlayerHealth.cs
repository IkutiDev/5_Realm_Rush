using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 10;
    [SerializeField] private int healthDecrease = 1;
    [SerializeField] private Text healthText;
    [SerializeField] private AudioClip enemyReachesBaseSFX;

    private void Start()
    {
        healthText.text = health.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8) // Enemy layer is number 8
        {
            DecreaseBaseHealth();
        }
    }

    private void DecreaseBaseHealth()
    {
        health -= healthDecrease;
        healthText.text = health.ToString();
        GetComponent<AudioSource>().PlayOneShot(enemyReachesBaseSFX);
    }
}

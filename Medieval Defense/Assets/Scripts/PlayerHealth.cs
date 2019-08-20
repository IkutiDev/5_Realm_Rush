using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 10;
    [SerializeField] private int healthDecrease = 1;
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
    }
}

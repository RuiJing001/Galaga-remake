using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeathBuff : MonoBehaviour
{
    PlayerHealth playerHealth;
    public int amount;

    // void awake()
    // {
    //     playerHealth = FindObjectType<PlayerHealth>();
    // }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (playerHealth.currentHealth < playerHealth.maxHealth)
            {
                Destroy(gameObject);
                playerHealth.currentHealth += amount;
            }
        }
    }
}


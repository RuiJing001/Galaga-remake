using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health of the enemy.
    private int currentHealth;  // Current health of the enemy.

    private ScoreManagerScript scoreManager; // Reference to the ScoreManagerScript.
    public GameObject diVFXprefab;
    public AudioClip destroySound; // Sound to play when the enemy is destroyed.
    private bool hasDied = false; // Flag to track if the enemy has already died.

    private void Start()
    {
        currentHealth = maxHealth; // Initialize current health to max health.

        // Find and assign the ScoreManagerScript in the scene.
        scoreManager = FindObjectOfType<ScoreManagerScript>();
    }

    public void TakeDamage(int damage)
    {
        // Reduce the enemy's health by the damage amount.
        currentHealth -= damage;

        // Check if the enemy's health is zero or less.
        if (currentHealth <= 0 && !hasDied)
        {
            Die(); // Call the Die function when health reaches zero.
        }
    }

    private void Die()
    {
        // Perform any death-related actions here, such as particle effects.

        // Play the destroy sound.
        if (destroySound != null)
        {
            AudioSource.PlayClipAtPoint(destroySound, transform.position);
        }

        // Increase the player's score using the ScoreManagerScript.
        if (scoreManager != null)
        {
            scoreManager.IncreaseScore(1); // Adjust the score increase amount as needed.
        }

        // Set the hasDied flag to true to prevent multiple spawns of VFX.
        hasDied = true;

        // Instantiate the current enemy prefab at the chosen spawn point.
        Instantiate(diVFXprefab, transform.position, Quaternion.identity);

        // Destroy the enemy GameObject.
        Destroy(gameObject);
    }
}

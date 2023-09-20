using System.Collections;

using UnityEngine;
using UnityEngine.UI; // Add this line to access UI components.

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 50; // Maximum health of the player.
    public int currentHealth;  // Current health of the player.

    public Slider healthSlider; // Reference to the health slider.

    public GameObject gameOverPannel;
    public GameObject diVFX;
    private void Start()
    {
        currentHealth = maxHealth; // Initialize current health to max health.
        gameOverPannel.SetActive(false);
        UpdateHealthSlider(); // Update the health slider on start.
        diVFX.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        // Reduce the player's health by the damage amount.
        currentHealth -= damage;

        // Check if the player's health is zero or less.
        if (currentHealth <= 0)
        {
            Die(); // Call the Die function when health reaches zero.
        }

        UpdateHealthSlider(); // Update the health slider.
    }

    private void Die()
    {
        gameOverPannel.SetActive(true);

        // Perform any death-related actions here, such as game over or respawn logic.
        // For this example, we'll simply deactivate the player GameObject.
       
        diVFX.SetActive(true);
        // Start the coroutine to destroy the VFX after a certain duration
        StartCoroutine(VfxDestroy());

    }
    private IEnumerator VfxDestroy()
    {
        // Wait for a specified duration before destroying the VFX
        yield return new WaitForSeconds(2f);

        // Destroy the VFX GameObject
        Destroy(diVFX);
        gameObject.SetActive(false);
    }
    private void UpdateHealthSlider()
    {
        if (healthSlider != null)
        {
            // Update the slider's value to reflect the current health.
            healthSlider.value = (float)currentHealth / maxHealth;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }
}

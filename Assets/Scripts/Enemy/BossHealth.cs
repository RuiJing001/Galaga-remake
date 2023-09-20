using UnityEngine;
using UnityEngine.UI; // Add this line to access UI components.
using System.Collections;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 50; // Maximum health of the boss.
    public int currentHealth;  // Current health of the boss.

    public Slider healthSlider; // Reference to the health slider.
    public GameObject diVFX;
    public AudioClip destroySound; // Sound to play when the enemy is destroyed.
  

   
    private void Start()
    {
        currentHealth = maxHealth; // Initialize current health to max health.
        UpdateHealthSlider(); // Update the health slider on start.
        diVFX.SetActive(false);
 
    }

    public void TakeDamage(int damage)
    {
        // Reduce the boss's health by the damage amount.
        currentHealth -= damage;

        // Check if the boss's health is zero or less.
        if (currentHealth <= 0)
        {
            Die(); // Call the Die function when health reaches zero.
        }

        UpdateHealthSlider(); // Update the health slider.
    }

    private void Die()
    {
        // Perform any boss death-related actions here, such as dropping loot or ending the boss fight.
        // For this example, we'll simply destroy the boss GameObject.
   
        diVFX.SetActive(true);
        // Start the coroutine to destroy the VFX after a certain duration
        StartCoroutine(VfxDestroy());
        // Play the destroy sound.
        if (destroySound != null)
        {
            AudioSource.PlayClipAtPoint(destroySound, transform.position);
        }

    }
    private IEnumerator VfxDestroy()
    {
        // Wait for a specified duration before destroying the VFX
        yield return new WaitForSeconds(2f);
        Destroy(diVFX);
        Destroy(gameObject);
        // Destroy the VFX GameObject
     
    }
    private void UpdateHealthSlider()
    {
        if (healthSlider != null)
        {
            // Update the slider's value to reflect the current boss health.
            healthSlider.value = (float)currentHealth / maxHealth;
        }
    }
}

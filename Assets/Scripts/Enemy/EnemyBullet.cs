using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damage = 5; // Damage dealt to the player on collision.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collision is with the player.
        if (collision.CompareTag("Player"))
        {
            // Get the PlayerHealth component from the player GameObject.
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

            // Check if the player has a health component.
            if (playerHealth != null)
            {
                // Deal damage to the player.
                playerHealth.TakeDamage(damage);

                // Destroy the bullet on collision.
                Destroy(gameObject);
            }
        }
    }
}

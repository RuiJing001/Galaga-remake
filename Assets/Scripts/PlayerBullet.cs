using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public int damage = 100; // Damage dealt to enemies on collision.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collision is with an enemy.
        if (collision.CompareTag("Enemy"))
        {
            // Get the EnemyHealth component from the collided enemy.
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();

            // Check if the enemy has a health component.
            if (enemyHealth != null)
            {
                // Deal damage to the enemy.
                enemyHealth.TakeDamage(damage);

                // Destroy the bullet on collision.
                Destroy(gameObject);
            }
        }
        // Check if the collision is with an enemy.
        if (collision.CompareTag("BEnemy"))
        {
            // Get the EnemyHealth component from the collided enemy.
            BossHealth enemyHealth = collision.GetComponent<BossHealth>();

            // Check if the enemy has a health component.
            if (enemyHealth != null)
            {
                // Deal damage to the enemy.
                enemyHealth.TakeDamage(1);

                // Destroy the bullet on collision.
                Destroy(gameObject);
            }
        }
    }
}

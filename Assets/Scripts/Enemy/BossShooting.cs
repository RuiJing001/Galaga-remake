using UnityEngine;

public class BossShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float shootCooldown = 0.5f;
    public float projectileSpeed = 10f;

    private float shootTimer = 0f;

    private void Update()
    {
        if (shootTimer <= 0f)
        {
            Shoot();
            shootTimer = shootCooldown;
        }

        shootTimer -= Time.deltaTime;
    }

    private void Shoot()
    {
        // Create a new projectile.
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        // Get the rigidbody of the projectile.
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // Apply a force to move the projectile forward.
        rb.velocity = transform.up * projectileSpeed;

    }

}



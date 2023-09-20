using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the movement speed as needed.
    public float movementInterval = 5f; // Time interval for changing movement direction.

    public AudioSource shootSound;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float shootCooldown = 0.5f;
    public float projectileSpeed = 10f;

    private Rigidbody2D rb;
    private Vector2 randomDirection;

    private float minX, maxX, minY, maxY;
    private float timeUntilChangeDirection = 0f;
    private float shootTimer = 0f;
    public bool isMovingToCenter = true; // Flag to control movement to the center.
    public bool isBossMove = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Calculate the screen boundaries in world coordinates.
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        minX = -screenBounds.x;
        maxX = screenBounds.x;
        minY = -screenBounds.y;
        maxY = screenBounds.y;

        // Start moving to the center when the game starts.
        MoveToCenter();
    }

    private void Update()
    {
      
        if (isBossMove)
        {

            if (isMovingToCenter)
            {
                // Move the boss towards the center.
                Vector2 center = new Vector2(0f, 0f);
                Vector2 directionToCenter = (center - (Vector2)transform.position).normalized;
                rb.velocity = directionToCenter * moveSpeed;

                // Check if the boss has reached the center.
                if (Vector2.Distance(transform.position, center) < 0.1f)
                {
                    isMovingToCenter = false; // Boss has reached the center.
                    StartMoving(); // Start the random movement.
                }

            }
            else
            {
                // Move the boss in the current direction.
                rb.velocity = randomDirection * moveSpeed;

                // Check if the boss is about to hit the screen edge and change direction if needed.
                if (transform.position.x - 5 < minX || transform.position.x + 5 > maxX ||
                    transform.position.y -10 < minY || transform.position.y + 10 > maxY)
                {
                    ChangeDirection();
                }

                // Check if it's time to change movement direction.
                if (Time.time >= timeUntilChangeDirection)
                {
                    StopMoving(); // Stop moving temporarily.
                    Invoke("StartMoving", Random.Range(1f, 5f)); // Wait for a random interval before moving again.
                }

                // Handle shooting behavior.
                if (shootTimer <= 0f)
                {
                    Shoot();
                    shootTimer = shootCooldown;
                }

                shootTimer -= Time.deltaTime;
            }

          

           
        }
    }

    private void ChangeDirection()
    {
        // Generate a random direction.
        randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    private void MoveToCenter()
    {
        isMovingToCenter = true;
        isBossMove = false;
        rb.velocity = Vector2.zero; // Stop the boss's movement.
    }

    private void StartMoving()
    {
        isBossMove = true;
        timeUntilChangeDirection = Time.time + movementInterval;
        ChangeDirection();
    }

    private void StopMoving()
    {
        isBossMove = false;
        rb.velocity = Vector2.zero; // Stop the boss's movement.
    }

    private void Shoot()
    {
        // Create a new projectile.
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        shootSound.Play();

    }

    private void StartShooting()
    {
        InvokeRepeating("Shoot", 0f, shootCooldown);
    }

    private void StopShooting()
    {
        CancelInvoke("Shoot");
    }
}

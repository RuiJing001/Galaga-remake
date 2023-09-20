using UnityEngine;
using System.Collections;

public class GalagaEnemy : MonoBehaviour
{
    public float entrySpeed = 2.0f;
    public float Speed = 1.5f;
    public float amplitude = 2.0f;
    public float frequency = 1.0f;
    public float shootingCooldown = 3.0f;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public AudioSource shootSound; // Reference to the AudioSource component.

    private float timeSinceLastShot = 0.0f;
    private float minX, maxX;
    private float screenHeight;
    private bool hasEnteredScreen = false;
    private bool EnemyStopMove;

    private void Start()
    {
        float screenWidth = Camera.main.aspect * Camera.main.orthographicSize;
        minX = -screenWidth + amplitude;
        maxX = screenWidth - amplitude;
        screenHeight = Camera.main.orthographicSize;
        EnemyStopMove = true;
    }

    private void Update()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }

        if (!hasEnteredScreen)
        {
            EnterScreen();
        }
        else
        {
            StartCoroutine(EnemyStartTime(5f));
        }
    }

    private void EnterScreen()
    {
        Vector3 newPosition = transform.position;
        newPosition.y -= entrySpeed * Time.deltaTime;
        transform.position = newPosition;

        if (transform.position.y <= 3)
        {
            hasEnteredScreen = true;
        }
    }

    private IEnumerator EnemyStartTime(float WaitTime)
    {
        yield return new WaitForSeconds(WaitTime);
        MoveWithSineWave();
        Shoot();
    }

    private void MoveWithSineWave()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.Clamp(newPosition.x + Mathf.Sin(Time.time * frequency) * 1.5F * Time.deltaTime, minX, maxX);
        newPosition.y -= Speed * Time.deltaTime;
        transform.position = newPosition;
    }

    private void Shoot()
    {
        timeSinceLastShot += Time.deltaTime;

        if (timeSinceLastShot >= shootingCooldown)
        {
            Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

            // Play the shooting sound.
            if (shootSound != null)
            {
                shootSound.Play();
            }

            timeSinceLastShot = 0.0f;
        }
    }
}

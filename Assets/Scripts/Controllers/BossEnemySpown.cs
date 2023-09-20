using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemySpown : MonoBehaviour
{
    public GameObject[] enemyPrefabs;  // An array of enemy prefabs to spawn.
    public int[] spawnCounts;          // An array of spawn counts for each enemy prefab.
    public float[] spawnIntervals;     // An array of spawn intervals for each enemy prefab set.
    public Transform[] spawnPoints;    // An array of spawn points where enemies can appear.

    private int currentEnemyIndex = 0; // Index of the current enemy prefab set to spawn.
    private int currentSpawnCount = 0; // Current spawn count for the current enemy prefab.
    private float currentSpawnInterval = 0f; // Current spawn interval for the current enemy prefab set.

    private bool isSpawning = false;    // Flag to control spawning process.
    private ScoreManagerScript scoreManager; // Reference to the ScoreManagerScript.
    private BossMovement BosMove; // Reference to the ScoreManagerScript.
    private BossHealth Boshelth; // Reference to the ScoreManagerScript.
    public int SpownLimit;
    private void Start()
    {
        // Set the initial spawn interval.
        if (spawnIntervals.Length > 0)
        {
            currentSpawnInterval = spawnIntervals[0];
        }

        // Start the spawning coroutine.
        StartCoroutine(SpawnEnemies());
        scoreManager = FindObjectOfType<ScoreManagerScript>();
        BosMove = FindObjectOfType<BossMovement>();
        Boshelth = FindObjectOfType<BossHealth>();
        isSpawning = true;
    }


    private void Update()
    {
        if (BosMove.isMovingToCenter)
        {
            isSpawning = true;
           
        }
        if (Boshelth.currentHealth <= 0 )
        {
            isSpawning = false;
          
        }
    }
    private IEnumerator SpawnEnemies()
    {
        while (isSpawning)
        {
            if (currentSpawnCount < spawnCounts[currentEnemyIndex])
            {
                // Choose a random spawn point from the array.
                Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

                // Instantiate the current enemy prefab at the chosen spawn point.
                Instantiate(enemyPrefabs[currentEnemyIndex], randomSpawnPoint.position, Quaternion.identity);

                currentSpawnCount++;

                // Wait for the specified spawn interval before spawning the next enemy.
                yield return new WaitForSeconds(currentSpawnInterval);
            }
            else
            {
                // Reset spawn count and move to the next enemy prefab set.
                currentSpawnCount = 0;
                currentEnemyIndex = (currentEnemyIndex + 1) % enemyPrefabs.Length;

                if (currentEnemyIndex < spawnIntervals.Length)
                {
                    // Wait for the specified interval before moving to the next enemy prefab set.
                    currentSpawnInterval = spawnIntervals[currentEnemyIndex];
                }
            }
        }
    }

    public void StopSpawning()
    {
        isSpawning = false;
    }
}

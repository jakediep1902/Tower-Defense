using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab; // The enemy prefab to be spawned
    public Transform spawnPoint; // The point where enemies will spawn
    public float timeBetweenWaves = 5f; // Time interval between each wave of enemies
    private float countdown = 2f; // Initial countdown before the first wave spawns

    private int waveNumber = 0; // Track the number of waves that have been spawned

    void Update()
    {
        // Check if the countdown timer has reached zero or below
        if (countdown <= 0f)
        {
            // Start the coroutine to spawn a wave of enemies
            StartCoroutine(SpawnWave());

            // Reset the countdown timer to the time between waves
            countdown = timeBetweenWaves;
        }

        // Decrease the countdown timer over time
        countdown -= Time.deltaTime;
    }

    // Coroutine to handle spawning a wave of enemies
    IEnumerator SpawnWave()
    {
        waveNumber++; // Increment the wave number for each new wave

        // Spawn enemies equal to the wave number
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy(); // Spawn a single enemy
            yield return new WaitForSeconds(0.5f); // Wait 0.5 seconds before spawning the next enemy
        }
    }

    // Method to spawn an enemy at the spawn point
    void SpawnEnemy()
    {
        // Instantiate an enemy prefab at the spawn point's position and rotation
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}

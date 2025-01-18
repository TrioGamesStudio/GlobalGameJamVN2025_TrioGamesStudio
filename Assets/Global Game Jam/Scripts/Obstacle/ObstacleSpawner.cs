using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Spawning Settings")]
    public GameObject birdPrefab; // Bird prefab to spawn
    public GameObject[] spawnPoints; // Array of predefined spawn points
    public float spawnInterval = 0.5f; // Time between spawns
    public float spawnDuration = 5f; // Total duration for spawning birds
    public float birdLifetime = 10f; // Time before birds are destroyed

    private bool isSpawning = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isSpawning)
        {
            StartCoroutine(SpawnBirds());
        }
    }

    private IEnumerator SpawnBirds()
    {
        isSpawning = true;
        float endTime = Time.time + spawnDuration;

        while (Time.time < endTime)
        {
            SpawnBird();
            yield return new WaitForSeconds(spawnInterval);
        }

        isSpawning = false;
    }

    private void SpawnBird()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogWarning("No spawn points assigned!");
            return;
        }

        // Randomly select a spawn point
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex].transform;

        // Instantiate the bird at the selected spawn point
        GameObject bird = Instantiate(birdPrefab, spawnPoint.position, Quaternion.identity);

        // Schedule bird destruction
        Destroy(bird, birdLifetime);
    }
}

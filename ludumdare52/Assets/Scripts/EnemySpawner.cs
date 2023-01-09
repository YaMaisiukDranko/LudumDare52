using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // The object that we want to instantiate
    public GameObject[] enemies;

    // The time in seconds between each spawn
    public float spawnInterval = 5f;

    // The timer for when the next spawn should occur
    private float spawnTimer = 0f;

    public int enemyCount;

    void Update()
    {
        // Increase the timer by the elapsed time since the last frame
        spawnTimer += Time.deltaTime;

        // If the timer has reached the spawn interval, spawn an object and reset the timer
        if (spawnTimer >= spawnInterval && enemyCount > 0)
        {
            // Spawn the object at the position and rotation of the spawner
            Instantiate(enemies[Random.Range(0, enemies.Length)], transform.position, transform.rotation);
            enemyCount--;
            // Reset the timer
            spawnTimer = 0f;
        }
    }
}

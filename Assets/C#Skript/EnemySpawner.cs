using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    public float initialSpawnInterval = 1f;

    public int numberOfWaves = 3;
    public int enemiesInFirstWave = 3;
    public float spawnIntervalDecreasePerWave = 0.2f;

    private int currentWave = 0;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (currentWave < numberOfWaves)
        {
            currentWave++;
            int enemiesToSpawn = enemiesInFirstWave + (currentWave - 1) * 2;
            float currentSpawnInterval = Mathf.Max(0.2f, initialSpawnInterval - spawnIntervalDecreasePerWave * (currentWave - 1)); // не меньше 0.2 сек

            Debug.Log("Wave " + currentWave + " started. Spawn interval: " + currentSpawnInterval);

            for (int i = 0; i < enemiesToSpawn; i++)
            {
                Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
                yield return new WaitForSeconds(currentSpawnInterval);
            }

            Debug.Log("Wave " + currentWave + " completed!");
            yield return new WaitForSeconds(timeBetweenWaves);
        }

        Debug.Log("All waves completed!");
    }
}

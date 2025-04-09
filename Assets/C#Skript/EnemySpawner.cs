using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public float spawnInterval = 2f;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
{
    GameObject enemyObj = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    Enemy enemyScript = enemyObj.GetComponent<Enemy>();

    // Вказуємо ціль (наприклад, башню)
    enemyScript.target = GameObject.FindWithTag("Tower").transform;
}

}

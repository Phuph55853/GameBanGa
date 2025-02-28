using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(-8f, 8f);
        Instantiate(enemyPrefab, new Vector3(randomX, 6f, 0), Quaternion.identity);
    }
}

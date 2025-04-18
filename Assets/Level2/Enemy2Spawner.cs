using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Spawner : MonoBehaviour
{
    public GameObject enemy2Prefab;
    public float spawnInterval = 5f;
    public int maxEnemy2Count = 20; // Giới hạn tối đa 20 con
    private int currentEnemy2Count = 0;

    void Start()
    {
        InvokeRepeating("SpawnEnemy2", 2f, spawnInterval);
    }

    void SpawnEnemy2()
    {
        if (currentEnemy2Count < maxEnemy2Count)
        {
            Vector2 spawnPos = new Vector2(Random.Range(-7f, 7f), 5f);
            Instantiate(enemy2Prefab, spawnPos, Quaternion.identity);
            currentEnemy2Count++; // Tăng biến đếm số lượng Enemy2
        }
    }

    public void Enemy2Destroyed()
    {
        currentEnemy2Count--; // Giảm số lượng khi Enemy2 bị tiêu diệt
    }
}

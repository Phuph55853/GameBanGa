using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public GameObject eggPrefab;  // Prefab trứng
    public Transform eggSpawnPoint; // Vị trí đẻ trứng
    public float eggSpawnInterval = 3f; // Khoảng thời gian đẻ trứng
    public float moveSpeed = 2f; // Tốc độ di chuyển ngang

    private bool movingRight = true;

    void Start()
    {
        InvokeRepeating("LayEgg", 2f, eggSpawnInterval);
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float moveDirection = movingRight ? 1 : -1;
        transform.Translate(Vector2.right * moveSpeed * moveDirection * Time.deltaTime);

        // Đảo chiều khi chạm giới hạn màn hình
        if (transform.position.x > 7f) movingRight = false;
        if (transform.position.x < -7f) movingRight = true;
    }

    void LayEgg()
    {
        if (eggPrefab != null && eggSpawnPoint != null)
        {
            Instantiate(eggPrefab, eggSpawnPoint.position, Quaternion.identity);
            //Debug.Log("🐣 Enemy2 đã đẻ trứng!");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}

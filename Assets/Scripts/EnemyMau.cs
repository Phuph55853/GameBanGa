using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMau : MonoBehaviour
{
    public int maxHealth = 3;  // Máu tối đa
    private int currentHealth;

    public GameObject drumstickPrefab;  // Prefab đùi gà

    void Start()
    {
        currentHealth = maxHealth;
        //Debug.Log(gameObject.name + " có " + currentHealth + " máu");
    }

    public void TakeDamage()
    {
        currentHealth--;  // Giảm máu mỗi lần trúng đạn
        //Debug.Log(gameObject.name + " bị bắn! Máu còn lại: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void SpawnDrumstick()
    {
        if (drumstickPrefab != null)
        {
            Instantiate(drumstickPrefab, transform.position, Quaternion.identity);
        }
    }
    void Die()
    {
        SpawnDrumstick();  // Gọi hàm rơi đùi gà

        //Debug.Log(gameObject.name + " đã chết!");
        Destroy(gameObject);
    }

}

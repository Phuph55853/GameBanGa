using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVaChamGa : MonoBehaviour
{
    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>(); // Lấy script PlayerHealth
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy") || collision.CompareTag("Enemy2"))
        {

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(playerHealth.maxHealth); // Trừ hết máu


            }

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drumstick : MonoBehaviour
{
    public int healAmount = 1;  // Hồi 1 máu

    void Start()
    {
        Destroy(gameObject, 3f);  // Hủy đùi gà sau 3 giây
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.EatDrumstick();  // Gọi hàm trong PlayerHealth
                Debug.Log("Player đã ăn 1 đùi gà.");
            }
            Destroy(gameObject); // Hủy đùi gà sau khi ăn
        }
    }
}

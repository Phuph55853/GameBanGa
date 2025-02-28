using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public float fallSpeed = 2f;

    void Update()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
    }

    void Start()
    {
        Destroy(gameObject, 3f);  // Hủy trứng sau 3 giây
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerMau playerHealth = collision.GetComponent<PlayerMau>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(); // Gây sát thương cho Player
            }
            Destroy(gameObject); // Hủy trứng sau khi va chạm
        }
        //else if (collision.CompareTag("Ground"))
        //{
        //    Destroy(gameObject);
        //    Debug.Log("Trứng chạm đất và vỡ!");
        //}
    }
}

using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float _speed = 500;
    public float liftTime;
    public GameObject effect_bullet;
    Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        Destroy(gameObject, 3f);  // Hủy đạn sau 3 giây
    }
    private void Update()
    {
        _rb.velocity = transform.up * _speed * Time.deltaTime;

        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Enemy2"))
        {
            EnemyMau enemyHealth = collision.GetComponent<EnemyMau>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage();  // Giảm máu của enemy  
            }
            Destroy(gameObject);  // Hủy viên đạn sau khi trúng enemy  
        }
        //if (collision.CompareTag("Enemy"))
        //{
        //    EnemyMau enemyHealth = collision.GetComponent<EnemyMau>();
        //    if (enemyHealth != null)
        //    {
        //        enemyHealth.TakeDamage();  // Gọi hàm trừ máu
        //        //Debug.Log("Bắn trúng Enemy!"); // In ra console kiểm tra
        //    }
        //    Destroy(gameObject);  // Hủy viên đạn
        //}
        //else if (collision.CompareTag("Enemy2"))
        //{
        //    EnemyMau enemyHealth = collision.GetComponent<EnemyMau>();
        //    if (enemyHealth != null)
        //    {
        //        enemyHealth.TakeDamage();  // Gọi hàm trừ máu
        //        //Debug.Log("Bắn trúng Enemy!"); // In ra console kiểm tra
        //    }
        //    Destroy(gameObject);  // Hủy viên đạn

        //}


    }




    internal void SetSpeed(float bulletSpeed)
    {
        throw new NotImplementedException();
    }
}

using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 1f;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Tự hủy khi ra khỏi màn hình
        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject); // Enemy chết
        }
    }
}

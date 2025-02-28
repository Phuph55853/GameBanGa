using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    public float bulletSpeed = 10f;
    public int ammoCount = 3; // Số lần bắn/người chơi có thể bắn

    [SerializeField] Transform firePoint;



    void Update()
    {
        // Di chuyển
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(moveX, moveY, 0) * speed * Time.deltaTime);

        // Bắn đạn
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
            ammoCount--; // Mỗi lần bắn giảm 1 đạn
        }
    }

    void Shoot()
    {
        //Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * bulletSpeed;


    }
}

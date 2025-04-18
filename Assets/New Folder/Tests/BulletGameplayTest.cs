using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class BulletGameplayTest
{
    private GameObject player;
    private PlayerController controller;

    [SetUp]
    public void SetUp()
    {
        // Tạo player
        player = new GameObject("Player");
        controller = player.AddComponent<PlayerController>();
        controller.speed = 5f;
        controller.bulletSpeed = 10f;

        // Tạo đạn prefab mới KHÔNG dùng CreatePrimitive
        GameObject bulletPrefab = new GameObject("Bullet");
        bulletPrefab.AddComponent<CircleCollider2D>();
        bulletPrefab.AddComponent<Rigidbody2D>();
        bulletPrefab.tag = "Bullet";

        controller.bulletPrefab = bulletPrefab;

        // Tạo firePoint
        var firePointObj = new GameObject("FirePoint");
        firePointObj.transform.position = Vector3.zero;
        controller.GetType()
            .GetField("firePoint", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(controller, firePointObj.transform);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(player);
        foreach (var obj in Object.FindObjectsOfType<GameObject>())
        {
            Object.DestroyImmediate(obj);
        }
    }

    [UnityTest]
    public IEnumerator Shoot_Bullet_Is_Instantiated()
    {
        int initialBulletCount = Object.FindObjectsOfType<Rigidbody2D>().Length;
        controller.Shoot();
        yield return new WaitForSeconds(0.1f);

        int afterBulletCount = Object.FindObjectsOfType<Rigidbody2D>().Length;
        Assert.Greater(afterBulletCount, initialBulletCount, "Bullet không được tạo ra sau khi bắn.");
    }

    [UnityTest]
    public IEnumerator Bullet_Does_Not_Hit_Enemy()
    {
        // Tạo enemy ở xa
        GameObject enemy = GameObject.CreatePrimitive(PrimitiveType.Cube);
        enemy.transform.position = new Vector3(0, 20f, 0);
        enemy.tag = "Enemy";
        enemy.AddComponent<BoxCollider2D>();

        controller.Shoot();
        yield return new WaitForSeconds(1f);

        // Kiểm tra enemy vẫn tồn tại
        Assert.IsTrue(enemy != null, "Enemy không được phép bị trúng đạn nhưng đã bị huỷ.");
    }

    [UnityTest]
    public IEnumerator Bullet_Hits_Enemy()
    {
        // Tạo enemy gần vị trí bắn
        GameObject enemy = GameObject.CreatePrimitive(PrimitiveType.Cube);
        enemy.transform.position = new Vector3(0, 1.5f, 0); // Gần player
        enemy.tag = "Enemy";
        enemy.AddComponent<BoxCollider2D>();

        // Thêm script xử lý va chạm
        enemy.AddComponent<EnemySpawner>(); // Script bên dưới

        controller.Shoot();
        yield return new WaitForSeconds(1f);

        // Enemy sẽ tự huỷ nếu trúng đạn
        Assert.IsTrue(enemy == null || enemy.Equals(null), "Enemy đáng lẽ bị trúng đạn nhưng vẫn tồn tại.");
    }
}

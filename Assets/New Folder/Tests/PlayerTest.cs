using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerControllerTests
{
    GameObject playerObj;
    PlayerController player;

    [SetUp]
    public void SetUp()
    {
        playerObj = new GameObject("Player");
        player = playerObj.AddComponent<PlayerController>();

        // Setup fire point và bullet prefab
        GameObject firePointObj = new GameObject("FirePoint");
        firePointObj.transform.position = Vector3.zero;
        player.bulletSpawn = firePointObj.transform;

        GameObject bulletPrefab = new GameObject("Bullet");
        bulletPrefab.AddComponent<Rigidbody2D>();
        player.bulletPrefab = bulletPrefab;

        player.ammoCount = 3;
        player.bulletSpeed = 10f;
    }

    [Test]
    public void Test_Ammo_Decreases_When_Shooting()
    {
        // Tạo Player và gán component
        var playerObject = new GameObject("Player");
        var player = playerObject.AddComponent<PlayerController>();

        // Gán bulletPrefab giả có Rigidbody2D
        var bulletPrefab = new GameObject("BulletPrefab");
        bulletPrefab.AddComponent<Rigidbody2D>(); // BẮT BUỘC

        player.bulletPrefab = bulletPrefab;

        // Gán firePoint giả
        var firePoint = new GameObject("FirePoint").transform;
        player.bulletSpawn = firePoint;

        // Thiết lập đạn
        player.ammoCount = 3;

        // Gọi hàm Shoot()
        player.Shoot();

        // Kiểm tra xem ammo có giảm
        Assert.AreEqual(2, player.ammoCount);
    }


    [Test]
    public void Test_Bullet_Is_Instantiated_When_Shoot()
    {
        int beforeBullet = Object.FindObjectsOfType<Rigidbody2D>().Length;
        player.Shoot();
        int afterBullet = Object.FindObjectsOfType<Rigidbody2D>().Length;
        Assert.AreEqual(beforeBullet + 1, afterBullet);
    }

    [Test]
    public void Test_Cannot_Shoot_If_Ammo_Zero()
    {
        player.ammoCount = 0;
        player.Shoot();
        int bulletCount = Object.FindObjectsOfType<Rigidbody2D>().Length;
        Assert.AreEqual(0, bulletCount); // Không sinh viên đạn nào
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(playerObj);
        foreach (var obj in Object.FindObjectsOfType<GameObject>())
        {
            Object.DestroyImmediate(obj);
        }
    }
}

using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

public class PlayerGameplayTest
{
    private GameObject player;
    private PlayerController controller;

    [SetUp]
    public void SetUp()
    {
        player = new GameObject("Player");
        controller = player.AddComponent<PlayerController>();

        // Tạo prefab đạn giả có Rigidbody2D
        GameObject bulletPrefab = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        bulletPrefab.AddComponent<Rigidbody2D>(); // ✅ thêm Rigidbody2D
        controller.bulletPrefab = bulletPrefab;

        // Tạo điểm bắn giả
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
    }

    [UnityTest]
    public IEnumerator Player_Moves_Left()
    {
        Vector3 startPos = player.transform.position;
        controller.MoveLeft();
        yield return new WaitForSeconds(0.1f);
        Assert.Less(player.transform.position.x, startPos.x, "Player không di chuyển sang trái.");
    }

    [UnityTest]
    public IEnumerator Player_Moves_Right()
    {
        Vector3 startPos = player.transform.position;
        controller.MoveRight();
        yield return new WaitForSeconds(0.1f);
        Assert.Greater(player.transform.position.x, startPos.x, "Player không di chuyển sang phải.");
    }

    [UnityTest]
    public IEnumerator Player_Moves_And_Shoots()
    {
        Vector3 startPos = player.transform.position;
        controller.MoveRight();
        controller.Shoot();
        yield return new WaitForSeconds(0.1f);

        Assert.Greater(player.transform.position.x, startPos.x, "Player không di chuyển.");
        Assert.IsTrue(controller.isShooting, "Player không bắn.");
    }
}

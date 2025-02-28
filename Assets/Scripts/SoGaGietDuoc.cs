using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoGaGietDuoc : MonoBehaviour
{
    public static SoGaGietDuoc instance;  // Singleton để dễ truy cập
    
    public int killCount = 0;            // Số gà đã giết
    public TextMeshProUGUI killCountText;          // Text hiển thị điểm
    public PlayerController playerController; // Tham chiếu tới PlayerController để tăng đạn và tốc độ


    void Awake()
    {
        // Đảm bảo chỉ có một GameManager tồn tại
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        UpdateKillCountUI();
    }

    public void AddKill()
    {
        killCount++;                  // Tăng số gà đã giết
        UpdateKillCountUI();          // Cập nhật UI
        


        // Khi giết được 10 con gà
        if (killCount == 10)
        {
            playerController.bulletSpeed *= 500f;   // Gấp đôi tốc độ đạn
            playerController.ammoCount += 1;      // Tăng thêm 1 viên đạn
            Debug.Log("🎯 Đạt 10 kill: +1 đạn và x2 tốc độ đạn!");
        }
    }

    void UpdateKillCountUI()
    {
        killCountText.text = " " + killCount;
    }
    
}

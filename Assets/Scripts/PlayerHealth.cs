using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    private int drumstickCount = 0;  // Đếm số đùi gà đã ăn

    public GameObject[] hearts;  // Mảng chứa hình trái tim

    public Text drumstickText; // UI hiển thị số đùi gà


    void Start()
    {
        currentHealth = maxHealth;
        UpdateHearts();
        UpdateDrumstickUI(); // Cập nhật UI ban đầu

    }

    public void TakeDamage()
    {
        if (currentHealth > 0)
        {
            currentHealth--;
            UpdateHearts();
            if (currentHealth <= 0)
            {
                GameOver();
            }
        }
    }

    public void EatDrumstick()
    {
        drumstickCount++;  // Tăng số đùi gà đã ăn
        UpdateDrumstickUI(); // Cập nhật UI

        //Debug.Log("Đùi gà đã ăn: " + drumstickCount);

        if (drumstickCount >= 10)  // Nếu đủ 10 đùi gà thì hồi máu
        {
            Heal(1);
            drumstickCount = 0; // Reset bộ đếm
            UpdateDrumstickUI(); // Cập nhật lại UI sau khi reset
            //Debug.Log("Hồi 1 máu! Reset đếm đùi gà.");
        }
    }

    void Heal(int amount)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += amount;
            if (currentHealth > maxHealth) currentHealth = maxHealth;
            UpdateHearts();
        }
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(i < currentHealth);
        }
    }
    void UpdateDrumstickUI()
    {
        if (drumstickText != null)
        {
            drumstickText.text = "Drumsticks: " + drumstickCount + "/10";
        }
    }
    void GameOver()
    {
        Debug.Log("Game Over!");
        // Hiển thị UI Game Over ở đây
    }

    internal void TakeDamage(int maxHealth)
    {
        throw new NotImplementedException();
    }
}

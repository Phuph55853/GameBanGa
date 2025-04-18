using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;  // Tham chiếu đến UI Game Over

    public void ShowGameOver()
    {
        gameOverUI.SetActive(true);  // Hiển thị màn hình Game Over
        Time.timeScale = 0f;  // Dừng thời gian (pause game)
    }

    public void RetryGame()
    {
        Time.timeScale = 1f;  // Reset thời gian
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // Load lại màn chơi
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1f;  // Reset thời gian
        SceneManager.LoadScene("MainMenu");  // Chuyển về menu chính (đổi tên Scene nếu cần)
    }
}

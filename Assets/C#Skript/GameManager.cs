using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject winPanel;
    public GameObject losePanel;

    private int totalWaves = 3;
    private int currentWave = 0;
    private int enemiesAlive = 0;
    private bool gameEnded = false;

    void Awake()
    {
        if (instance == null) instance = this;
        Time.timeScale = 1f;
    }

    public void StartWave(int enemies)
    {
        currentWave++;
        enemiesAlive += enemies; // 🟡 Додаємо ворогів до лічильника
    }

    public void EnemyDied()
    {
        enemiesAlive--;

        if (enemiesAlive <= 0 && currentWave >= totalWaves)
        {
            Win(); // 🟢 Перемога лише коли ВСІ вороги вбиті
        }
    }

    public void EnemyReachedTower()
    {
        Lose();
    }

    void Win()
    {
        if (gameEnded) return;
        gameEnded = true;
        Time.timeScale = 0f;
        winPanel.SetActive(true);
    }

    void Lose()
    {
        if (gameEnded) return;
        gameEnded = true;
        Time.timeScale = 0f;
        losePanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    public int enemyCount = 0;
    public int playerCount = 0;

    public GameObject victoryPanel;
    public GameObject losePanel;
    public void EnemyDestroyed()
    {
            enemyCount--;
            CheckVictoryCondition();
    }

    public void PlayerDestroyed()
    {
            playerCount--;
            CheckVictoryCondition();
    }

    public void CheckVictoryCondition()
    {
        if (enemyCount == 0)
        {
            Victory();
            Debug.Log("Победа!");
        }
        else if (playerCount == 0)
        {
            Lose();
            Debug.Log("Поражение!");
        }
    }

    public void Victory()
    {
        Time.timeScale = 0f;
        victoryPanel.SetActive(true);

    }

    public void Lose()
    {
        Time.timeScale = 0f;
        losePanel.SetActive(true);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MenuController menuController;

    public float gameTimeLimit;

    private int m_score;
    private float m_gameTimer;

    private bool m_isGameStarted;

    private void Start()
    {
        m_isGameStarted = false;
        Time.timeScale = 1;
        ResetScore();
    }

    private void Update()
    {
        if (m_isGameStarted)
        {
            IncreaseGameTimer();
            CheckGameOver();
        }
    }

    public void StartGame() => m_isGameStarted = true;

    public void IncreaseScore(int value)
    {
        m_score += value;
        m_gameTimer -= 5;
        menuController.UpdateScore(m_score);
    }

    private void ResetScore() => m_score = 0;

    private void CheckGameOver()
    {
        if (m_gameTimer >= gameTimeLimit)
        {
            m_isGameStarted = false;
            Time.timeScale = 0;
            menuController.EndGame(m_score);
        }
    }

    private void IncreaseGameTimer()
    {
        m_gameTimer += Time.deltaTime;
        menuController.UpdateTimer(gameTimeLimit - m_gameTimer);
    }
}
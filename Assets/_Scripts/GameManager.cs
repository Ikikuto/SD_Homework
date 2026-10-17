using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameScore gameScore;
    [SerializeField] private ScoreUI finalScoreText;
    private bool isGameOver;

    private void Start()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    public void GameOver()
    {
        if (isGameOver)
        {
            return;
        }

        isGameOver = true;

        if (gameScore != null && finalScoreText != null)
        {
            finalScoreText.SetFinalScore(gameScore.Score);
        }

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(
            SceneManager.
            GetActiveScene().buildIndex);
    }

}

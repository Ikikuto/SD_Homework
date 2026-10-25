using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject gamePausePanel;
    [SerializeField] private GameScore gameScore;
    [SerializeField] private ScoreUI finalScoreText;
    private bool isGameOver;
    private bool isPause = false;

    private void Start()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        if (gamePausePanel != null)
            gamePausePanel.SetActive(false);
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

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; //Sau khi game over

        if (GameSession.Instance != null)
        {
            GameSession.Instance.ResetSession();
        }

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f; //Sau khi game over
        SceneManager.LoadScene("MainMenuScene");
    }

    public void Resume()
    {
        if (gamePausePanel != null)
            gamePausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        if (gamePausePanel != null)
                gamePausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    private void Update()
    {
        //Nhan ESC ON/OFF PausePanel
        //Khi game over ko the interact
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGameOver) return;

            isPause = !isPause;
            if(isPause)
                Pause();
            else
                Resume();
        }
    }

    
}

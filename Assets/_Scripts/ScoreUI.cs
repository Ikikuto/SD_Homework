using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    public void SetScore(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void SetFinalScore(int score)
    {
        scoreText.text = "Final Score: " + score + " !!";
    }
}

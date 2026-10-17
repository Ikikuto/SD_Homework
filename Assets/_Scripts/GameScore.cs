using System.Collections.Generic;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    [SerializeField] private ScoreUI updateScore;
    private int score;
    public int Score
    {
        get
        {
            return score;
        }
    }

    private void Start()
    {
        UpdateUI();
    }

    public void AddScore(int amount)
    {
        if (amount <= 0)
        {
            return;
        }

        score += amount;

        UpdateUI();
    }

    private void UpdateUI()
    {
        if(updateScore != null)
        {
            updateScore.SetScore(score);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            AddScore(10);
        }
    }

}

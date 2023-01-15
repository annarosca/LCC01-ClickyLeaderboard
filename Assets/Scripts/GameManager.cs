using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private float timerSeconds = 5;
    [SerializeField] private GameObject activeGameUI;
    [SerializeField] private GameObject gameOverUI;
    private bool gameOver = false;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI finalScoreText;

    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score;
    }

    private void Update()
    {
        if (timerSeconds > 0)
        {
            timerSeconds -= Time.deltaTime;
        }
        else
        {
            gameOver = true;
            finalScoreText.text = "Final Score: " + score;
            activeGameUI.SetActive(false);
            gameOverUI.SetActive(true);
        }
        scoreText.text = "Score: " + score;
        timerText.text = timerSeconds.ToString("F0") + " sec";

    }

    public void IncreaseScore()
    {
        if (!gameOver)
        {
            score++;
        }
    }
}

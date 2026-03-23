using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;


    void Start()
    {
        GameManager.Instance.OnScoreChanged += UpdateScore;
        GameManager.Instance.OnHealthChanged += UpdateHealth;
        GameManager.Instance.OnGameOver += HandleGameOver;

        //Events only fire when something changes.
        //Scene loads - nothing to be changed
        //Manually initialize v
        UpdateScore(GameManager.Instance.score);
        UpdateHealth(GameManager.Instance.health);
    }


    void UpdateScore(int newScore)
    {
        scoreText.text =  "Score: " + newScore;
        Debug.Log("Score updated: " + newScore);
    }

    void UpdateHealth(int newHealth)
    {
        healthText.text = "Health: " + newHealth;
        Debug.Log("Health updated: " + newHealth);
    }

    void HandleGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}

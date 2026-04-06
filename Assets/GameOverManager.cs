using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameOverManager : MonoBehaviour
{
    public TMP_InputField playerNameInput;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText.text = "Final Score: " + GameManager.Instance.score;
    }

    public void OnSubmitScore()
    {
        string playerName = playerNameInput.text;

        if (string.IsNullOrEmpty(playerName))
        {
            playerName = "Anonymous";
        }

        int finalScore = GameManager.Instance.score;
        float completionTime = Time.timeSinceLevelLoad;

        DatabaseManager.Instance.SaveScore(playerName, finalScore, completionTime);

        SceneManager.LoadScene("HighScores");
    }

    public void GoAgain()
    {
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene("GameScene");
    }
}
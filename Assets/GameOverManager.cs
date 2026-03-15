using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText.text = "Final Score: " + GameManager.Instance.score;
    }

    public void GoAgain()
    {
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene("GameScene");
    }
}
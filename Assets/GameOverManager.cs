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
        int finalScore = PlayerPrefs.GetInt("FinalScore");
        scoreText.text = "Final Score: " + finalScore;
    }

    public void GoAgain()
    {
        SceneManager.LoadScene("GameScene");
    }
}
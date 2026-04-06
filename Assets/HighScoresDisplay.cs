using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class HighScoresDisplay : MonoBehaviour
{
    public TextMeshProUGUI[] scoreTexts;

    private void Start()
    {
        DisplayHighScores();
    }

    void DisplayHighScores()
    {
        List<HighScore> topScores = DatabaseManager.Instance.GetTopHighScores(5);

        if (topScores.Count == 0)
        {
            for (int i = 0; i < scoreTexts.Length; i++)
                scoreTexts[i].text = (i + 1) + ". No scores yet!";
            return;
        }

        for (int i = 0; i < scoreTexts.Length; i++)
        {
            if (i < topScores.Count)
                scoreTexts[i].text = (i + 1) + ". " + topScores[i].PlayerName +
                    " pts - " + topScores[i].CompletionTime.ToString("F1") + "s";
            else
                scoreTexts[i].text = (i + 1) + ". ---";
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
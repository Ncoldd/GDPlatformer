using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public int score = 0;
    public int health = 100;

    // Delegates / Events
    public event Action<int> OnScoreChanged;
    public event Action<int> OnHealthChanged;
    public event Action OnGameOver;

    void Awake()
    {
        if (Instance != null && Instance != this) // only one instance allowed
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        AudioManager.Instance.PlayMusic(AudioManager.Instance.backgroundMusic);
        DontDestroyOnLoad(gameObject); // survive scene changes
    }

    public void AddScore(int amount)
    {
        score += amount;
        OnScoreChanged?.Invoke(score); // notify listeners

        if (score >= 90)
        {
            TriggerGameOver();
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        OnHealthChanged?.Invoke(health);

        if (health <= 0)
        {
            TriggerGameOver();
        }

    }

    public void TriggerGameOver()
    {
        OnGameOver?.Invoke();
    }

    public void ResetGame()
    {
        score = 0;
        health = 100;
    }

}
